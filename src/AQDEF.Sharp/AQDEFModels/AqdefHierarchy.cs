using System;
using System.Collections.Generic;
using System.Linq;

namespace AQDEF.Sharp.Models {
    /// <summary>
    /// Contains information about hierarchy of <i>parts / characteristics /
    /// groups</i>. There are two types of hiearchy definition within the AQDEF
    /// structure:
    /// <ul>
    /// <li>reagular hiearchy stored in {@code K51xx} keys</li>
    /// <li>simplified characteristics hierarchy stored in {@code K2030/K2031}
    /// keys</li>
    /// </ul>
    /// Hierarchy model can be created only from one hierarchy type. Creating model
    /// from both types together is <strong>NOT</strong> supported.
    /// <para>
    /// <strong>The simplified characteristics hierarchy</strong>
    /// </para>
    /// <para>
    /// The simplified characteristics hierarchy from {@code K2030/K2031} keys is
    /// internally transformed to the {@code K51xx} structure. In other words, there
    /// is no way to get information about simple hierarchy back from the hierarchy
    /// model.
    /// </para>
    /// <para>
    /// Note that hierarchy model created from a simplified characteristics hierarchy
    /// needs to be <seealso cref="#normalize(AqdefObjectModel) normalized"/>, because
    /// there could be characteristics without binding to a root part node, or there
    /// could be no root part node at all.
    /// </para>
    /// 
    /// @author Vlastimil Dolejs
    /// @author Honza Krakora
    /// </summary>
    /// <seealso cref= #normalize(AqdefObjectModel)
    ///  </seealso>
    public class AqdefHierarchy {

        //*******************************************
        // Attributes
        //*******************************************

        private static readonly KKey KeyPartNode = KKey.Of("K5111");
        private static readonly KKey KeyCharacteristicNode = KKey.Of("K5112");
        private static readonly KKey KeyGroupNode = KKey.Of("K5113");

        private static readonly KKey KeyNodeBinding = KKey.Of("K5103");
        private static readonly KKey KeyCharacteristicBinding = KKey.Of("K5102");

        private static readonly KKey KeySimpleGroupingCharacteristicParent = KKey.Of("K2030");
        private static readonly KKey KeySimpleGroupingCharacteristicChild = KKey.Of("K2031");

        private SortedDictionary<NodeIndex, HierarchyEntry> _nodeDefinitions = new SortedDictionary<NodeIndex, HierarchyEntry>();
        private SortedDictionary<NodeIndex, IList<HierarchyEntry>> _nodeBindings = new SortedDictionary<NodeIndex, IList<HierarchyEntry>>();

        private bool _containsHierarchyInformation = false;
        private bool _containsSimpleHierarchyInformation = false;

        //*******************************************
        // Methods
        //*******************************************

        public virtual void PutEntry(KKey kKey, int index, object value) {
            if (kKey == null) {
                throw new ArgumentNullException(nameof(kKey));
            }

            if (kKey.IsSimpleHierarchyLevel) {
                PutSimpleHierarchyEntry(kKey, index, value);

            } else if (IsNodeDefinition(kKey) || IsBinding(kKey)) {
                NodeIndex nodeIndex = NodeIndex.Of(index);
                PutEntry(new HierarchyEntry(kKey, nodeIndex, (int?)value));

            } else {
                throw new System.ArgumentException($"Unknown hierarchy entry. Key: {kKey}  Value:{value}");
            }
        }

        public virtual void PutEntry(HierarchyEntry entry) {
            if (entry == null) {
                throw new ArgumentNullException(nameof(entry));
            }

            KKey kKey = entry.Key;

            if (kKey.IsSimpleHierarchyLevel) {
                throw new Exception("Direct insertion of simple hierarchy entry is not supported.");
            }

            if (_containsSimpleHierarchyInformation) {
                throw new Exception("Combination of hierarchy (K51xx) and simple hierarchy (K2030/2031) is not supported.");
            }

            PutEntryInternal(entry);

            _containsHierarchyInformation = true;
        }

        private void PutSimpleHierarchyEntry(KKey kKey, int? index, object value) {
            if (value == null) {
                return;
            }

            int valueInt = (int)value;

            // simple hierarchy entry with value 0 has no information - it's the same as if there is no record
            if (valueInt == 0) {
                return;
            }

            if (_containsHierarchyInformation) {
                throw new Exception("Combination of hierarchy (K51xx) and simple hierarchy (K2030/2031) is not supported.");
            }

            NodeIndex nodeIndex = NodeIndex.Of(valueInt);

            if (IsCharacteristicSimpleGroupingParent(kKey)) {

                // create characteristic node
                HierarchyEntry hierarchyEntry = new HierarchyEntry(KeyCharacteristicNode, nodeIndex, index);
                PutEntryInternal(hierarchyEntry);

            } else if (IsCharacteristicSimpleGroupingChild(kKey)) {

                HierarchyEntry hierarchyEntry;
                var existingNodeIndexOfCharacteristic = GetNodeIndexOfCharacteristic(index);

                if (existingNodeIndexOfCharacteristic!=null) {
                    // bind characteristic node to its parent node
                    int? existingNodeIndexOfCharacteristicInt = existingNodeIndexOfCharacteristic.Index;
                    hierarchyEntry = new HierarchyEntry(KeyNodeBinding, nodeIndex, existingNodeIndexOfCharacteristicInt);

                } else {
                    // bind characteristic to its parent node
                    hierarchyEntry = new HierarchyEntry(KeyCharacteristicBinding, nodeIndex, index);
                }

                PutEntryInternal(hierarchyEntry);

            } else {
                throw new System.ArgumentException($"Unknown simple hierarchy entry.Key: {kKey}  Value:{value}");
            }

            _containsSimpleHierarchyInformation = true;
        }

        private void PutEntryInternal(HierarchyEntry entry) {
            KKey kKey = entry.Key;

            if (IsNodeDefinition(kKey)) {
                _nodeDefinitions[entry.Index] = entry;

            } else if (IsBinding(kKey)) {
                _nodeBindings.ComputeIfAbsent(entry.Index, k => new List<HierarchyEntry>()).Add(entry);

            } else {
                throw new System.ArgumentException($"Unknown hierarchy entry. Key: {kKey}  Value:{entry.Value}");
            }
        }

        /// <summary>
        /// Get the normalized hierarchy.
        /// </summary>
        /// <param name="aqdefObjectModel">
        ///            an aqdef model containing this hierarchy, must not be {@code null} </param>
        /// <returns> normalized hierarchy, the source hierarchy is not changed </returns>
        public virtual AqdefHierarchy Normalize(AqdefObjectModel aqdefObjectModel) {
            //requireNonNull(aqdefObjectModel);

            if (this != aqdefObjectModel.Hierarchy) {
                throw new System.ArgumentException("The provided aqdef model does not contain this normalized hierarchy.");
            }

            // currently we only normalize hierarchy created from a simple characteristics grouping
            AqdefHierarchy normalizedHierarchy = NormalizeSimpleCharacteristicsGrouping(aqdefObjectModel);

            return normalizedHierarchy;
        }

        private AqdefHierarchy NormalizeSimpleCharacteristicsGrouping(AqdefObjectModel aqdefObjectModel) {
            if (!_containsSimpleHierarchyInformation) {
                return this;
            }

            // this is a hierarchy created from a simple characteristics grouping
            // it means there should be no part node nor logical group nodes

            ForEachNodeDefinition(entry =>
            {
                KKey kKey = entry.Key;
                if (IsPartNode(kKey)) {
                    throw new System.InvalidOperationException("Hierarchy was created from a simple characteristics grouping. " + "It should not contain any part node element, but it does.");
                }
                if (IsGroupNode(kKey)) {
                    throw new System.InvalidOperationException("Hierarchy was created from a simple characteristics grouping. " + "It should not contain any logical group node element, but it does.");
                }
            });

            AqdefHierarchy normalizedHierarchy = new AqdefHierarchy();
            int hierarchyNodeIndexCounter = 0;

            aqdefObjectModel.ForEachPart(part =>
                // create a root part node
                // add all characteristic nodes with new indexes
                // bind all root characteristic nodes to the root part node
                // add all existing bindings with modified indexes
                // get the new index
                // bind all orphan characteristics to the root part node
            {
                int? partIndex = part.Index.Index;
                NodeIndex partNodeIndex = NodeIndex.Of(hierarchyNodeIndexCounter++);
                normalizedHierarchy.PutEntry(new HierarchyEntry(KeyPartNode, partNodeIndex, partIndex));
                var nodesIndexMap = new Dictionary<int?,int?>();
                ForEachNodeDefinition(entry =>
                {
                    KKey kKey = entry.Key;
                    int? characteristicIndex = (int?)entry.Value;
                    NodeIndex characteristicsNodeIndex = NodeIndex.Of(hierarchyNodeIndexCounter++);
                    normalizedHierarchy.PutEntry(new HierarchyEntry(kKey, characteristicsNodeIndex, characteristicIndex));
                    nodesIndexMap.Add(entry.Index.Index, characteristicsNodeIndex.Index);
                });
                ForEachNodeDefinition(entry =>
                {
                    NodeIndex oldNodeIndex = entry.Index;
                    int? nodeIndex = nodesIndexMap.GetValueOrNull(oldNodeIndex.Index);
                    if (GetParentNodeIndexOfNode(oldNodeIndex)!=null) {
                        normalizedHierarchy.PutEntry(new HierarchyEntry(KeyNodeBinding, partNodeIndex, nodeIndex));
                    }
                });
                ForEachNodeBinding(entry =>
                {
                    KKey kKey = entry.Key;
                    NodeIndex characteristicBindingSourceNodeIndex = entry.Index;
                    characteristicBindingSourceNodeIndex = NodeIndex.Of(nodesIndexMap.GetValueOrNull(characteristicBindingSourceNodeIndex.Index));
                    int? characteristicBindingTargetNodeIndex = (int?)entry.Value;
                    if (IsNodeBinding(kKey)) {
                        characteristicBindingTargetNodeIndex = nodesIndexMap.GetValueOrNull(characteristicBindingTargetNodeIndex);
                    }
                    normalizedHierarchy.PutEntry(new HierarchyEntry(kKey, characteristicBindingSourceNodeIndex, characteristicBindingTargetNodeIndex));
                });
                aqdefObjectModel.ForEachCharacteristic(part, characteristic =>
                {
                    CharacteristicIndex characteristicIndex = characteristic.Index;
                    int? characteristicIndexInt = characteristicIndex.Index;
                    if (GetNodeIndexOfCharacteristic(characteristicIndexInt)!=null || GetParentNodeIndexOfCharacteristic(characteristicIndexInt)!=null) {
                        return;
                    }
                    normalizedHierarchy.PutEntry(new HierarchyEntry(KeyCharacteristicBinding, partNodeIndex, characteristicIndex.Index));
                });
            });

            return normalizedHierarchy;
        }

        public virtual void ForEachNodeDefinition(Action<HierarchyEntry> action) {
            _nodeDefinitions.Values.ForEach(action);
        }

        public virtual void ForEachNodeBinding(Action<HierarchyEntry> action) {
            _nodeBindings.Values.SelectMany(v=>v).ForEach(action);
        }

        public virtual bool Empty {
            get {
                return _nodeDefinitions.Count == 0 && _nodeBindings.Count == 0;
            }
        }

        public virtual bool HasChildren(CharacteristicIndex characteristicIndex) {
            int? characteristicIndexInt = characteristicIndex == null ? null : characteristicIndex.Index;
            NodeIndex nodeIndexOfCharacteristic = GetNodeIndexOfCharacteristic(characteristicIndexInt);

            if (nodeIndexOfCharacteristic!=null) {
                IList<HierarchyEntry> children = _nodeBindings.GetValueOrNull(nodeIndexOfCharacteristic);
                return children.Any();
            }

            return false;
        }

        /// <summary>
        /// Find index of parent characteristic or group of given characteristic.
        /// </summary>
        /// <param name="characteristicIndex"> </param>
        /// <returns> optional containing <seealso cref="CharacteristicIndex"/> or <seealso cref="GroupIndex"/> of parent, or empty optional if given
        ///         characteristic do not have a parent </returns>
        public virtual object GetParentIndex(CharacteristicIndex characteristicIndex) {
            int? characteristicIndexInt = characteristicIndex == null ? null : characteristicIndex.Index;
            NodeIndex parentNodeIndexOfCharacteristic = GetParentNodeIndexOfCharacteristic(characteristicIndexInt);

            if (parentNodeIndexOfCharacteristic!=null) {
                // characteristic is directly assigned to parent
                return GetCharacteristicOrGroupIndexOfNode(parentNodeIndexOfCharacteristic, characteristicIndex.PartIndex);

            } else {
                NodeIndex nodeIndexOfCharacteristic = GetNodeIndexOfCharacteristic(characteristicIndexInt);

                if (nodeIndexOfCharacteristic!=null) {
                    // characteristic is defined as node that may be assigned to parent node
                    NodeIndex parentNodeIndex = GetParentNodeIndexOfNode(nodeIndexOfCharacteristic);

                    if (parentNodeIndex!=null) {
                        return GetCharacteristicOrGroupIndexOfNode(parentNodeIndex, characteristicIndex.PartIndex);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Find index of parent characteristic or group of given group.
        /// </summary>
        /// <param name="groupIndex"> </param>
        /// <returns> optional containing <seealso cref="CharacteristicIndex"/> or <seealso cref="GroupIndex"/>
        ///         of parent, or empty optional if given group do not have a parent </returns>
        public virtual object GetParentIndex(GroupIndex groupIndex) {
            var groupIndexInt = groupIndex?.Index;
            NodeIndex nodeIndexOfGroup = GetNodeIndexOfGroup(groupIndexInt);

            if (nodeIndexOfGroup!=null) {
                NodeIndex parentNodeIndex = GetParentNodeIndexOfNode(nodeIndexOfGroup);

                if (parentNodeIndex!=null) {
                    return GetCharacteristicOrGroupIndexOfNode(parentNodeIndex, groupIndex.PartIndex);
                }
            }

            return null;
        }

        /// <summary>
        /// If the given node is characteristic or group returns its <seealso cref="CharacteristicIndex"/> or <seealso cref="GroupIndex"/>.
        /// </summary>
        /// <param name="nodeIndex"> </param>
        /// <param name="partIndex">
        /// @return </param>
        private object GetCharacteristicOrGroupIndexOfNode(NodeIndex nodeIndex, PartIndex partIndex) {
            HierarchyEntry nodeDefinition = _nodeDefinitions.GetValueOrNull(nodeIndex);
            int? index = (int?)nodeDefinition.Value;

            if (nodeDefinition.Key.Equals(KeyCharacteristicNode)) {
                return CharacteristicIndex.Of(partIndex, index);

            } else if (nodeDefinition.Key.Equals(KeyGroupNode)) {
                return GroupIndex.Of(partIndex, index);

            } else {
                return null;
            }
        }

        /// <summary>
        /// return nodeBindings.values().stream().flatMap(list -> list.stream()).filter(hierarchyEntry -> {
        ///         return hierarchyEntry.getKey().equals(KEY_NODE_BINDING)&& nodeIndex.getIndex().equals(hierarchyEntry.getValue());
        /// }).map(HierarchyEntry::getIndex).findAny();
        /// </summary>
        /// <param name="nodeIndex"></param>
        /// <returns></returns>
        private NodeIndex GetParentNodeIndexOfNode(NodeIndex nodeIndex) {
            return _nodeBindings.Values.SelectMany(v=>v).
                Where(hierarchyEntry => hierarchyEntry.Key.Equals(KeyNodeBinding) && nodeIndex.Index.Equals(hierarchyEntry.Value))
                .Select(h=>h.Index).FirstOrDefault();
        }

        private NodeIndex GetParentNodeIndexOfCharacteristic(int? characteristicIndex) {
            if (characteristicIndex == null) {
                return null;
            }

            return _nodeBindings.Values.
                SelectMany(v => v)
                .Where(hierarchyEntry=>hierarchyEntry.Key.Equals(KeyCharacteristicBinding) && characteristicIndex.Equals(hierarchyEntry.Value))
                .Select(h=>h.Index).FirstOrDefault();
        }

        private NodeIndex GetNodeIndexOfGroup(int? groupIndex) {
            if (groupIndex == null) {
                return null;
            }

            return _nodeDefinitions.Where(entry =>{
                HierarchyEntry hierarchyEntry = entry.Value;
                return KeyGroupNode.Equals(hierarchyEntry.Key) && groupIndex.Equals(hierarchyEntry.Value);
            }).Select(e=>e.Key).First();
        }

        private NodeIndex GetNodeIndexOfCharacteristic(int? characteristicIndex) {
            if (characteristicIndex == null) {
                return null;
            }

            return _nodeDefinitions.Where(entry =>
            {
                HierarchyEntry hierarchyEntry = entry.Value;
                return KeyCharacteristicNode.Equals(hierarchyEntry.Key) && characteristicIndex.Equals(hierarchyEntry.Value);
            }).Select(e => e.Key).First();
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((_nodeBindings == null) ? 0 : _nodeBindings.GetHashCode());
            result = prime * result + ((_nodeDefinitions == null) ? 0 : _nodeDefinitions.GetHashCode());
            return result;
        }

        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }

            if (!(obj is AqdefHierarchy)) {
                return false;
            }
            AqdefHierarchy other = (AqdefHierarchy)obj;
            if (_nodeBindings == null) {
                if (other._nodeBindings != null) {
                    return false;
                }
            } else if (!_nodeBindings.Equals(other._nodeBindings)) {
                return false;
            }
            if (_nodeDefinitions == null) {
                if (other._nodeDefinitions != null) {
                    return false;
                }
            } else if (!_nodeDefinitions.Equals(other._nodeDefinitions)) {
                return false;
            }
            return true;
        }

        private bool IsBinding(KKey kKey) {
            return IsNodeBinding(kKey) || IsCharacteristicBinding(kKey);
        }

        /// <summary>
        /// Binding between node and another node (group or characteristic that contins
        /// child characteristics).
        /// </summary>
        /// <param name="kKey">
        /// @return </param>
        private static bool IsNodeBinding(KKey kKey) {
            return kKey.Equals(KeyNodeBinding);
        }

        /// <summary>
        /// Binding between node and characteristic that does not contin child characteristics.
        /// </summary>
        /// <param name="kKey">
        /// @return </param>
        private static bool IsCharacteristicBinding(KKey kKey) {
            return kKey.Equals(KeyCharacteristicBinding);
        }


        private static bool IsNodeDefinition(KKey kKey) {
            return IsPartNode(kKey) || IsCharacteristicNode(kKey) || IsGroupNode(kKey);
        }

        private static bool IsPartNode(KKey kKey) {
            return kKey.Equals(KeyPartNode);
        }

        private static bool IsCharacteristicNode(KKey kKey) {
            return kKey.Equals(KeyCharacteristicNode);
        }

        private static bool IsGroupNode(KKey kKey) {
            return kKey.Equals(KeyGroupNode);
        }

        private static bool IsCharacteristicSimpleGroupingParent(KKey kKey) {
            return kKey.Equals(KeySimpleGroupingCharacteristicParent);
        }

        private static bool IsCharacteristicSimpleGroupingChild(KKey kKey) {
            return kKey.Equals(KeySimpleGroupingCharacteristicChild);
        }

        //*******************************************
        // Inner classes
        //*******************************************

        public class HierarchyEntry : AbstractEntry<NodeIndex> {

            public HierarchyEntry(KKey key, NodeIndex index, int? value) : base(ValidateKey(key), index, value) {
            }

            private static KKey ValidateKey(KKey key) {
                if (!key.IsHierarchyLevel) {
                    throw new System.ArgumentException("K-Key of hierarchy type expected, but found: " + key);
                }
                return key;
            }
        }

    }
}