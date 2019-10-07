using System;
using System.Collections.Generic;
using System.Linq;

namespace AQDEF.Sharp.AQDEFModels {
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

        private static readonly KKey KEY_PART_NODE = KKey.Of("K5111");
        private static readonly KKey KEY_CHARACTERISTIC_NODE = KKey.Of("K5112");
        private static readonly KKey KEY_GROUP_NODE = KKey.Of("K5113");

        private static readonly KKey KEY_NODE_BINDING = KKey.Of("K5103");
        private static readonly KKey KEY_CHARACTERISTIC_BINDING = KKey.Of("K5102");

        private static readonly KKey KEY_SIMPLE_GROUPING_CHARACTERISTIC_PARENT = KKey.Of("K2030");
        private static readonly KKey KEY_SIMPLE_GROUPING_CHARACTERISTIC_CHILD = KKey.Of("K2031");

        private SortedDictionary<NodeIndex, HierarchyEntry> NodeDefinitions = new SortedDictionary<NodeIndex, HierarchyEntry>();
        private SortedDictionary<NodeIndex, IList<HierarchyEntry>> NodeBindings = new SortedDictionary<NodeIndex, IList<HierarchyEntry>>();

        private bool ContainsHierarchyInformation = false;
        private bool ContainsSimpleHierarchyInformation = false;

        //*******************************************
        // Methods
        //*******************************************

        public virtual void putEntry(KKey kKey, int index, object value) {
            if (kKey == null) {
                throw new ArgumentNullException(nameof(kKey));
            }

            if (kKey.IsSimpleHierarchyLevel) {
                putSimpleHierarchyEntry(kKey, index, value);

            } else if (isNodeDefinition(kKey) || isBinding(kKey)) {
                NodeIndex nodeIndex = NodeIndex.Of(index);
                putEntry(new HierarchyEntry(kKey, nodeIndex, (int?)value));

            } else {
                throw new System.ArgumentException($"Unknown hierarchy entry. Key: {kKey}  Value:{value}");
            }
        }

        public virtual void putEntry(HierarchyEntry entry) {
            if (entry == null) {
                throw new ArgumentNullException(nameof(entry));
            }

            KKey kKey = entry.Key;

            if (kKey.IsSimpleHierarchyLevel) {
                throw new Exception("Direct insertion of simple hierarchy entry is not supported.");
            }

            if (ContainsSimpleHierarchyInformation) {
                throw new Exception("Combination of hierarchy (K51xx) and simple hierarchy (K2030/2031) is not supported.");
            }

            putEntryInternal(entry);

            ContainsHierarchyInformation = true;
        }

        private void putSimpleHierarchyEntry(KKey kKey, int? index, object value) {
            if (value == null) {
                return;
            }

            int valueInt = (int)value;

            // simple hierarchy entry with value 0 has no information - it's the same as if there is no record
            if (valueInt == 0) {
                return;
            }

            if (ContainsHierarchyInformation) {
                throw new Exception("Combination of hierarchy (K51xx) and simple hierarchy (K2030/2031) is not supported.");
            }

            NodeIndex nodeIndex = NodeIndex.Of(valueInt);

            if (isCharacteristicSimpleGroupingParent(kKey)) {

                // create characteristic node
                HierarchyEntry hierarchyEntry = new HierarchyEntry(KEY_CHARACTERISTIC_NODE, nodeIndex, index);
                putEntryInternal(hierarchyEntry);

            } else if (isCharacteristicSimpleGroupingChild(kKey)) {

                HierarchyEntry hierarchyEntry;
                var existingNodeIndexOfCharacteristic = getNodeIndexOfCharacteristic(index);

                if (existingNodeIndexOfCharacteristic!=null) {
                    // bind characteristic node to its parent node
                    int? existingNodeIndexOfCharacteristicInt = existingNodeIndexOfCharacteristic.Index;
                    hierarchyEntry = new HierarchyEntry(KEY_NODE_BINDING, nodeIndex, existingNodeIndexOfCharacteristicInt);

                } else {
                    // bind characteristic to its parent node
                    hierarchyEntry = new HierarchyEntry(KEY_CHARACTERISTIC_BINDING, nodeIndex, index);
                }

                putEntryInternal(hierarchyEntry);

            } else {
                throw new System.ArgumentException($"Unknown simple hierarchy entry.Key: {kKey}  Value:{value}");
            }

            ContainsSimpleHierarchyInformation = true;
        }

        private void putEntryInternal(HierarchyEntry entry) {
            KKey kKey = entry.Key;

            if (isNodeDefinition(kKey)) {
                NodeDefinitions[entry.Index] = entry;

            } else if (isBinding(kKey)) {
                NodeBindings.computeIfAbsent(entry.Index, k => new List<HierarchyEntry>()).Add(entry);

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
        public virtual AqdefHierarchy normalize(AqdefObjectModel aqdefObjectModel) {
            //requireNonNull(aqdefObjectModel);

            if (this != aqdefObjectModel.Hierarchy) {
                throw new System.ArgumentException("The provided aqdef model does not contain this normalized hierarchy.");
            }

            // currently we only normalize hierarchy created from a simple characteristics grouping
            AqdefHierarchy normalizedHierarchy = normalizeSimpleCharacteristicsGrouping(aqdefObjectModel);

            return normalizedHierarchy;
        }

        private AqdefHierarchy normalizeSimpleCharacteristicsGrouping(AqdefObjectModel aqdefObjectModel) {
            if (!ContainsSimpleHierarchyInformation) {
                return this;
            }

            // this is a hierarchy created from a simple characteristics grouping
            // it means there should be no part node nor logical group nodes

            forEachNodeDefinition(entry =>
            {
                KKey kKey = entry.Key;
                if (isPartNode(kKey)) {
                    throw new System.InvalidOperationException("Hierarchy was created from a simple characteristics grouping. " + "It should not contain any part node element, but it does.");
                }
                if (isGroupNode(kKey)) {
                    throw new System.InvalidOperationException("Hierarchy was created from a simple characteristics grouping. " + "It should not contain any logical group node element, but it does.");
                }
            });

            AqdefHierarchy normalizedHierarchy = new AqdefHierarchy();
            int hierarchyNodeIndexCounter = 0;

            aqdefObjectModel.forEachPart(part =>
                // create a root part node
                // add all characteristic nodes with new indexes
                // bind all root characteristic nodes to the root part node
                // add all existing bindings with modified indexes
                // get the new index
                // bind all orphan characteristics to the root part node
            {
                int? partIndex = part.Index.Index;
                NodeIndex partNodeIndex = NodeIndex.Of(hierarchyNodeIndexCounter++);
                normalizedHierarchy.putEntry(new HierarchyEntry(KEY_PART_NODE, partNodeIndex, partIndex));
                var nodesIndexMap = new Dictionary<int?,int?>();
                forEachNodeDefinition(entry =>
                {
                    KKey kKey = entry.Key;
                    int? characteristicIndex = (int?)entry.Value;
                    NodeIndex characteristicsNodeIndex = NodeIndex.Of(hierarchyNodeIndexCounter++);
                    normalizedHierarchy.putEntry(new HierarchyEntry(kKey, characteristicsNodeIndex, characteristicIndex));
                    nodesIndexMap.Add(entry.Index.Index, characteristicsNodeIndex.Index);
                });
                forEachNodeDefinition(entry =>
                {
                    NodeIndex oldNodeIndex = entry.Index;
                    int? nodeIndex = nodesIndexMap.GetValueOrNull(oldNodeIndex.Index);
                    if (getParentNodeIndexOfNode(oldNodeIndex)!=null) {
                        normalizedHierarchy.putEntry(new HierarchyEntry(KEY_NODE_BINDING, partNodeIndex, nodeIndex));
                    }
                });
                forEachNodeBinding(entry =>
                {
                    KKey kKey = entry.Key;
                    NodeIndex characteristicBindingSourceNodeIndex = entry.Index;
                    characteristicBindingSourceNodeIndex = NodeIndex.Of(nodesIndexMap.GetValueOrNull(characteristicBindingSourceNodeIndex.Index));
                    int? characteristicBindingTargetNodeIndex = (int?)entry.Value;
                    if (isNodeBinding(kKey)) {
                        characteristicBindingTargetNodeIndex = nodesIndexMap.GetValueOrNull(characteristicBindingTargetNodeIndex);
                    }
                    normalizedHierarchy.putEntry(new HierarchyEntry(kKey, characteristicBindingSourceNodeIndex, characteristicBindingTargetNodeIndex));
                });
                aqdefObjectModel.forEachCharacteristic(part, characteristic =>
                {
                    CharacteristicIndex characteristicIndex = characteristic.Index;
                    int? characteristicIndexInt = characteristicIndex.Index;
                    if (getNodeIndexOfCharacteristic(characteristicIndexInt)!=null || getParentNodeIndexOfCharacteristic(characteristicIndexInt)!=null) {
                        return;
                    }
                    normalizedHierarchy.putEntry(new HierarchyEntry(KEY_CHARACTERISTIC_BINDING, partNodeIndex, characteristicIndex.Index));
                });
            });

            return normalizedHierarchy;
        }

        public virtual void forEachNodeDefinition(Action<HierarchyEntry> action) {
            NodeDefinitions.Values.forEach(action);
        }

        public virtual void forEachNodeBinding(Action<HierarchyEntry> action) {
            NodeBindings.Values.SelectMany(v=>v).forEach(action);
        }

        public virtual bool Empty {
            get {
                return NodeDefinitions.Count == 0 && NodeBindings.Count == 0;
            }
        }

        public virtual bool hasChildren(CharacteristicIndex characteristicIndex) {
            int? characteristicIndexInt = characteristicIndex == null ? null : characteristicIndex.Index;
            NodeIndex nodeIndexOfCharacteristic = getNodeIndexOfCharacteristic(characteristicIndexInt);

            if (nodeIndexOfCharacteristic!=null) {
                IList<HierarchyEntry> children = NodeBindings.GetValueOrNull(nodeIndexOfCharacteristic);
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
        public virtual object getParentIndex(CharacteristicIndex characteristicIndex) {
            int? characteristicIndexInt = characteristicIndex == null ? null : characteristicIndex.Index;
            NodeIndex parentNodeIndexOfCharacteristic = getParentNodeIndexOfCharacteristic(characteristicIndexInt);

            if (parentNodeIndexOfCharacteristic!=null) {
                // characteristic is directly assigned to parent
                return getCharacteristicOrGroupIndexOfNode(parentNodeIndexOfCharacteristic, characteristicIndex.PartIndex);

            } else {
                NodeIndex nodeIndexOfCharacteristic = getNodeIndexOfCharacteristic(characteristicIndexInt);

                if (nodeIndexOfCharacteristic!=null) {
                    // characteristic is defined as node that may be assigned to parent node
                    NodeIndex parentNodeIndex = getParentNodeIndexOfNode(nodeIndexOfCharacteristic);

                    if (parentNodeIndex!=null) {
                        return getCharacteristicOrGroupIndexOfNode(parentNodeIndex, characteristicIndex.PartIndex);
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
        public virtual object getParentIndex(GroupIndex groupIndex) {
            int? groupIndexInt = groupIndex == null ? null : groupIndex.Index;
            NodeIndex nodeIndexOfGroup = getNodeIndexOfGroup(groupIndexInt);

            if (nodeIndexOfGroup!=null) {
                NodeIndex parentNodeIndex = getParentNodeIndexOfNode(nodeIndexOfGroup);

                if (parentNodeIndex!=null) {
                    return getCharacteristicOrGroupIndexOfNode(parentNodeIndex, groupIndex.PartIndex);
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
        private object getCharacteristicOrGroupIndexOfNode(NodeIndex nodeIndex, PartIndex partIndex) {
            HierarchyEntry nodeDefinition = NodeDefinitions.GetValueOrNull(nodeIndex);
            int? index = (int?)nodeDefinition.Value;

            if (nodeDefinition.Key.Equals(KEY_CHARACTERISTIC_NODE)) {
                return CharacteristicIndex.of(partIndex, index);

            } else if (nodeDefinition.Key.Equals(KEY_GROUP_NODE)) {
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
        private NodeIndex getParentNodeIndexOfNode(NodeIndex nodeIndex) {
            return NodeBindings.Values.SelectMany(v=>v).
                Where(hierarchyEntry => hierarchyEntry.Key.Equals(KEY_NODE_BINDING) && nodeIndex.Index.Equals(hierarchyEntry.Value))
                .Select(h=>h.Index).FirstOrDefault();
        }

        private NodeIndex getParentNodeIndexOfCharacteristic(int? characteristicIndex) {
            if (characteristicIndex == null) {
                return null;
            }

            return NodeBindings.Values.
                SelectMany(v => v)
                .Where(hierarchyEntry=>hierarchyEntry.Key.Equals(KEY_CHARACTERISTIC_BINDING) && characteristicIndex.Equals(hierarchyEntry.Value))
                .Select(h=>h.Index).FirstOrDefault();
        }

        private NodeIndex getNodeIndexOfGroup(int? groupIndex) {
            if (groupIndex == null) {
                return null;
            }

            return NodeDefinitions.Where(entry =>{
                HierarchyEntry hierarchyEntry = entry.Value;
                return KEY_GROUP_NODE.Equals(hierarchyEntry.Key) && groupIndex.Equals(hierarchyEntry.Value);
            }).Select(e=>e.Key).First();
        }

        private NodeIndex getNodeIndexOfCharacteristic(int? characteristicIndex) {
            if (characteristicIndex == null) {
                return null;
            }

            return NodeDefinitions.Where(entry =>
            {
                HierarchyEntry hierarchyEntry = entry.Value;
                return KEY_CHARACTERISTIC_NODE.Equals(hierarchyEntry.Key) && characteristicIndex.Equals(hierarchyEntry.Value);
            }).Select(e => e.Key).First();
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((NodeBindings == null) ? 0 : NodeBindings.GetHashCode());
            result = prime * result + ((NodeDefinitions == null) ? 0 : NodeDefinitions.GetHashCode());
            return result;
        }

        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is AqdefHierarchy)) {
                return false;
            }
            AqdefHierarchy other = (AqdefHierarchy)obj;
            if (NodeBindings == null) {
                if (other.NodeBindings != null) {
                    return false;
                }
            } else if (!NodeBindings.Equals(other.NodeBindings)) {
                return false;
            }
            if (NodeDefinitions == null) {
                if (other.NodeDefinitions != null) {
                    return false;
                }
            } else if (!NodeDefinitions.Equals(other.NodeDefinitions)) {
                return false;
            }
            return true;
        }

        private bool isBinding(KKey kKey) {
            return isNodeBinding(kKey) || isCharacteristicBinding(kKey);
        }

        /// <summary>
        /// Binding between node and another node (group or characteristic that contins
        /// child characteristics).
        /// </summary>
        /// <param name="kKey">
        /// @return </param>
        private static bool isNodeBinding(KKey kKey) {
            return kKey.Equals(KEY_NODE_BINDING);
        }

        /// <summary>
        /// Binding between node and characteristic that does not contin child characteristics.
        /// </summary>
        /// <param name="kKey">
        /// @return </param>
        private static bool isCharacteristicBinding(KKey kKey) {
            return kKey.Equals(KEY_CHARACTERISTIC_BINDING);
        }


        private static bool isNodeDefinition(KKey kKey) {
            return isPartNode(kKey) || isCharacteristicNode(kKey) || isGroupNode(kKey);
        }

        private static bool isPartNode(KKey kKey) {
            return kKey.Equals(KEY_PART_NODE);
        }

        private static bool isCharacteristicNode(KKey kKey) {
            return kKey.Equals(KEY_CHARACTERISTIC_NODE);
        }

        private static bool isGroupNode(KKey kKey) {
            return kKey.Equals(KEY_GROUP_NODE);
        }

        private static bool isCharacteristicSimpleGroupingParent(KKey kKey) {
            return kKey.Equals(KEY_SIMPLE_GROUPING_CHARACTERISTIC_PARENT);
        }

        private static bool isCharacteristicSimpleGroupingChild(KKey kKey) {
            return kKey.Equals(KEY_SIMPLE_GROUPING_CHARACTERISTIC_CHILD);
        }

        //*******************************************
        // Inner classes
        //*******************************************

        public class HierarchyEntry : AbstractEntry<NodeIndex> {

            public HierarchyEntry(KKey key, NodeIndex index, int? value) : base(validateKey(key), index, value) {
            }

            private static KKey validateKey(KKey key) {
                if (!key.IsHierarchyLevel) {
                    throw new System.ArgumentException("K-Key of hierarchy type expected, but found: " + key);
                }
                return key;
            }
        }

    }
}