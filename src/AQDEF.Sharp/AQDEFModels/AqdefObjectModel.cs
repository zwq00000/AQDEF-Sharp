using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQDEF.Sharp.Parses;

namespace AQDEF.Sharp.Models {
    /// <summary>
    /// Object model of AQDEF content.
    /// <para>
    /// Provides methods to
    /// <ul>
    /// <li>manipulate with the content ({@code getXXX}, {@code putXXX},
    /// {@code removeXXX}, {@code filterXXX})</li>
    /// <li>iterate through the content {@code forEachXXX}</li>
    /// </ul>
    /// </para>
    /// <para>
    /// Use <seealso cref="AqdefParser"/> to read AQDEF content and <seealso cref="AqdefWriter"/> to
    /// write this object model as AQDEF content.
    /// </para>
    /// 
    /// @author Vlastimil Dolejs
    /// </summary>
    /// <seealso cref="AqdefParser"/>
    /// <seealso cref="AqdefWriter"/>
    public partial class AqdefObjectModel {



        private SortedDictionary<PartIndex, PartEntries> _partEntries = new SortedDictionary<PartIndex, PartEntries>();
        private SortedDictionary<PartIndex, SortedDictionary<CharacteristicIndex, CharacteristicEntries>> _characteristicEntries = new SortedDictionary<PartIndex, SortedDictionary<CharacteristicIndex, CharacteristicEntries>>();
        private SortedDictionary<PartIndex, SortedDictionary<GroupIndex, GroupEntries>> _groupEntries = new SortedDictionary<PartIndex, SortedDictionary<GroupIndex, GroupEntries>>();
        private SortedDictionary<PartIndex, SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>>> _valueEntries = new SortedDictionary<PartIndex, SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>>>();
        private AqdefHierarchy _hierarchyRenamed = new AqdefHierarchy();



        public virtual void PutPartEntry(KKey key, PartIndex index, object value) {
            if (value == null) {
                return;
            }

            PartEntries entriesWithIndex;
            if (!_partEntries.TryGetValue(index, out entriesWithIndex)) {
                entriesWithIndex = new PartEntries(index);
                _partEntries.Add(index, entriesWithIndex);
            }
            entriesWithIndex.Put(key, value);
        }
        /// <summary>
        /// Removes part entries with the given index.
        /// Characteristic and value entries of given part are preserved!
        /// </summary>
        /// <param name="index"> </param>
        private PartEntries RemovePartEntries(PartIndex index) {
            PartEntries entries;
            if (_partEntries.TryGetValue(index, out entries)) {
                _partEntries.Remove(index);
            }
            return entries;
        }
        public virtual void PutCharacteristicEntry(KKey key, CharacteristicIndex characteristicIndex, object value) {
            if (value == null) {
                return;
            }
            PartIndex partIndex = characteristicIndex.PartIndex;
            var entriesWithPartIndex = _characteristicEntries.ComputeIfAbsent(partIndex, i => new SortedDictionary<CharacteristicIndex, CharacteristicEntries>());
            CharacteristicEntries entriesWithIndex = entriesWithPartIndex.ComputeIfAbsent(characteristicIndex, i => new CharacteristicEntries(i));
            entriesWithIndex.Put(key,value);
        }
        /// <summary>
        /// Removes characteristic entries with the given index.
        /// Value entries of the given characteristic are preserved!
        /// </summary>
        /// <param name="index">
        /// @return </param>
        private CharacteristicEntries RemoveCharacteristicEntries(CharacteristicIndex index) {
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> entriesWithPartIndex = _characteristicEntries.GetValueOrNull(index.PartIndex);
            if (entriesWithPartIndex != null) {
                CharacteristicEntries removedEntries = entriesWithPartIndex.GetValueOrNull(index);
                
                if (entriesWithPartIndex.Count == 0) {
                    _characteristicEntries.Remove(index.PartIndex);
                }
                return removedEntries;
            }
            return null;
        }
        public virtual void PutGroupEntry(KKey key, GroupIndex groupIndex, object value) {
            if (value == null) {
                return;
            }
            PartIndex partIndex = groupIndex.PartIndex;
            SortedDictionary<GroupIndex, GroupEntries> entriesWithPartIndex = _groupEntries.ComputeIfAbsent(partIndex, i => new SortedDictionary<GroupIndex, GroupEntries>());
            GroupEntries entriesWithIndex = entriesWithPartIndex.ComputeIfAbsent(groupIndex, i => new GroupEntries(i));
            entriesWithIndex.Add(key, (GroupEntry) value);
        }
        public virtual void PutValueEntry(KKey key, ValueIndex valueIndex, object value) {
            if (value == null) {
                return;
            }
            PartIndex partIndex = valueIndex.PartIndex;
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> entriesWithPartIndex = _valueEntries.ComputeIfAbsent(partIndex, i => new SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>>());
            CharacteristicIndex characteristicIndex = valueIndex.CharacteristicIndex;
            SortedDictionary<ValueIndex, ValueEntries> entriesWithCharacteristicIndex = entriesWithPartIndex.ComputeIfAbsent(characteristicIndex, i => new SortedDictionary<ValueIndex, ValueEntries>());
            ValueEntries entriesWithIndex = entriesWithCharacteristicIndex.ComputeIfAbsent(valueIndex, i => new ValueEntries(i));
            entriesWithIndex.Add(key, (ValueEntry) value);
        }
        /// <summary>
        /// Removes all values of characteristic with the given index.
        /// </summary>
        /// <param name="index">
        /// @return </param>
        private IList<ValueEntries> RemoveValueEntries(CharacteristicIndex index) {
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> entriesWithPartIndex = _valueEntries.GetValueOrNull(index.PartIndex);
            if (entriesWithPartIndex != null) {
                SortedDictionary<ValueIndex, ValueEntries> removedValueEntries = entriesWithPartIndex.GetValueOrNull(index);

                if (entriesWithPartIndex.Count == 0) {
                    _valueEntries.Remove(index.PartIndex);
                }
                if (removedValueEntries != null) {
                    return new List<ValueEntries>(removedValueEntries.Values);
                }
            }
            return new List<ValueEntries>();
        }
        public virtual void PutHierarchyEntry(KKey kKey, int nodeIndex, object value) {
            _hierarchyRenamed.PutEntry(kKey, nodeIndex, value);
        }
        /// <summary>
        /// Returns indexes of all parts in this object model.
        /// 
        /// @return
        /// </summary>
        public virtual IList<PartIndex> PartIndexes {
            get {
                return new List<PartIndex>(_partEntries.Keys);
            }
        }
        public virtual PartEntries GetPartEntries(int index) {
            return GetPartEntries(PartIndex.Of(index));
        }
        public virtual PartEntries GetPartEntries(PartIndex index) {
            return _partEntries.GetValueOrNull(index);
        }
        /// <summary>
        /// Returns indexes of all characteristics of a part with the given index.
        /// 
        /// @return
        /// </summary>
        public virtual IList<CharacteristicIndex> GetCharacteristicIndexes(PartIndex partIndex) {
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> entriesWithPartIndex = _characteristicEntries.GetValueOrNull(partIndex);
            if (entriesWithPartIndex == null) {
                return new List<CharacteristicIndex>();
            } else {
                return new List<CharacteristicIndex>(entriesWithPartIndex.Keys);
            }
        }
        public virtual CharacteristicEntries GetCharacteristicEntries(int partIndex, int characteristicIndex) {
            return GetCharacteristicEntries(CharacteristicIndex.Of(PartIndex.Of(partIndex), characteristicIndex));
        }
        public virtual CharacteristicEntries GetCharacteristicEntries(CharacteristicIndex characteristicIndex) {
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> entriesWithPartIndex = _characteristicEntries.GetValueOrNull(characteristicIndex.PartIndex);
            if (entriesWithPartIndex == null) {
                return null;
            } else {
                return entriesWithPartIndex.GetValueOrNull(characteristicIndex);
            }
        }
        /// <summary>
        /// Returns indexes of all values of a characteristics with the given index.
        /// 
        /// @return
        /// </summary>
        public virtual ICollection<ValueIndex> GetValueIndexes(CharacteristicIndex characteristicIndex) {
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> entriesWithPartIndex = _valueEntries.GetValueOrNull(characteristicIndex.PartIndex);
            if (entriesWithPartIndex == null) {
                return new List<ValueIndex>();
            } else {
                SortedDictionary<ValueIndex, ValueEntries> entriesWithCharacteristicIndex = entriesWithPartIndex.GetValueOrNull(characteristicIndex);
                if (entriesWithCharacteristicIndex == null) {
                    return new List<ValueIndex>();
                } else {
                    return entriesWithCharacteristicIndex.Keys;
                }
            }
        }
        /// <summary>
        /// Returns indexes of all values in this object model.
        /// @return
        /// </summary>
        public virtual IList<ValueIndex> ValueIndexes {
            get {
                IList<ValueIndex> allValueIndexes = new List<ValueIndex>();
                foreach (SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> entriesOfPart in _valueEntries.Values) {
                    foreach (SortedDictionary<ValueIndex, ValueEntries> entriesOfCharacteristic in entriesOfPart.Values) {
                        ((List<ValueIndex>)allValueIndexes).AddRange(entriesOfCharacteristic.Keys);
                    }
                }
                return allValueIndexes;
            }
        }
        public virtual ValueEntries GetValueEntries(int partIndex, int characteristicIndex, int valueIndex) {
            return GetValueEntries(ValueIndex.Of(CharacteristicIndex.Of(PartIndex.Of(partIndex), characteristicIndex), valueIndex));
        }
        public virtual ValueEntries GetValueEntries(ValueIndex valueIndex) {
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> entriesWithPartIndex = _valueEntries.GetValueOrNull(valueIndex.PartIndex);
            if (entriesWithPartIndex == null) {
                return null;
            } else {
                SortedDictionary<ValueIndex, ValueEntries> entriesWithCharacteristicIndex = entriesWithPartIndex.GetValueOrNull(valueIndex.CharacteristicIndex);
                if (entriesWithCharacteristicIndex == null) {
                    return null;
                } else {
                    return entriesWithCharacteristicIndex.GetValueOrNull(valueIndex);
                }
            }
        }
        public virtual ICollection<ValueEntries> GetValueEntries(CharacteristicIndex characteristicIndex) {
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> entriesWithPartIndex = _valueEntries.GetValueOrNull(characteristicIndex.PartIndex);
            if (entriesWithPartIndex == null) {
                return new List<ValueEntries>();
            } else {
                SortedDictionary<ValueIndex, ValueEntries> entriesWithCharacteristicIndex = entriesWithPartIndex.GetValueOrNull(characteristicIndex);
                if (entriesWithCharacteristicIndex == null) {
                    return new List<ValueEntries>();
                } else {
                    return entriesWithCharacteristicIndex.Values;
                }
            }
        }

        public virtual IList<ValueSet> GetValueSets(PartIndex partIndex) {
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> entriesWithPartIndex = _valueEntries.GetValueOrNull(partIndex);
            IList<ValueSet> valueSets = new List<ValueSet>();
            foreach (var entriesOfCharacteristic in entriesWithPartIndex) {
                CharacteristicIndex characteristicIndex = entriesOfCharacteristic.Key;
                SortedDictionary<ValueIndex, ValueEntries> valuesOfCharacteristic = entriesOfCharacteristic.Value;
                int counter = 0;
                foreach (var valueEntries in valuesOfCharacteristic) {
                    while (counter >= valueSets.Count) {
                        valueSets.Add(new ValueSet());
                    }
                    ValueSet valueSet = valueSets[counter];
                    valueSet.AddValueOfCharacteristic(characteristicIndex, valueEntries.Value);
                    counter++;
                }
            }
            return valueSets;
        }
        /// <summary>
        /// Finds part index to which the given characteristic index belongs.
        /// <para>
        /// You should call this method only after this <seealso cref="AqdefObjectModel"/> is fully created.
        /// </para>
        /// </summary>
        /// <param name="characteristicIndex">
        /// @return </param>
        public virtual PartIndex FindPartIndexForCharacteristic(int characteristicIndex) {
            foreach (SortedDictionary<CharacteristicIndex, CharacteristicEntries> characteristics in _characteristicEntries.Values) {
                foreach (CharacteristicIndex characteristic in characteristics.Keys) {
                    if (characteristic.Index == characteristicIndex) {
                        return characteristic.PartIndex;
                    }
                }
            }
            return null;
        }
        public virtual ISet<CharacteristicIndex> FindCharacteristicIndexesForPart(PartIndex partIndex, Func<CharacteristicEntries,bool> predicate) {
            ISet<CharacteristicIndex> characteristicIndexes = new System.Collections.Generic.HashSet<CharacteristicIndex>();
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> partCharacteristics = _characteristicEntries.GetValueOrNull(partIndex);
            if (partCharacteristics != null) {
                foreach (CharacteristicEntries entries in partCharacteristics.Values) {
                    if (predicate(entries)) {
                        characteristicIndexes.Add(entries.Index);
                    }
                }
            }
            return characteristicIndexes;
        }
        /// <summary>
        /// Iterates through all parts
        /// </summary>
        /// <param name="consumer"> </param>
        public virtual void ForEachPart(Action<PartEntries> consumer) {
            _partEntries.ForEach((partIndex, part) => {
                consumer(part);
            });
        }
        /// <summary>
        /// Iterates through all characteristics of all parts
        /// </summary>
        /// <param name="consumer"> </param>
        public virtual void ForEachCharacteristic(Action<PartEntries, CharacteristicEntries> consumer) {
            _partEntries.ForEach((partIndex, part) => {
                var characteristicsOfPart = _characteristicEntries.GetValueOrNull(part.Index);
                if (characteristicsOfPart != null) {
                    characteristicsOfPart.ForEach((characteristicIndex, characteristic) => {
                        consumer(part, characteristic);
                    });
                }
            });
        }
        /// <summary>
        /// Iterates through all characteristics of the given part. Most of the time it will be used together with <seealso cref="#forEachPart(PartConsumer)"/>.
        /// <pre>
        /// model.forEachPart(part -> { 
        ///     model.forEachCharacteristic(part, characteristic -> {  });
        /// })
        /// </pre> </summary>
        /// <param name="part"> </param>
        /// <param name="consumer"> </param>
        public virtual void ForEachCharacteristic(PartEntries part, Action<CharacteristicEntries> consumer) {
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> characteristicsOfPart = _characteristicEntries.GetValueOrNull(part.Index);
            if (characteristicsOfPart != null) {
                characteristicsOfPart.ForEach((characteristicIndex, characteristic) => {
                    consumer(characteristic);
                });
            }
        }
        /// <summary>
        /// Iterates through all logical groups of all parts
        /// </summary>
        /// <param name="consumer"> </param>
        public virtual void ForEachGroup(Action<PartEntries, GroupEntries> consumer) {
            _partEntries.ForEach((partIndex, part) => {
                var groupsOfPart = _groupEntries.GetValueOrNull(part.Index);
                if (groupsOfPart != null) {
                    groupsOfPart.ForEach((groupIndex, group) => {
                        consumer(part, group);
                    });
                }
            });
        }
        /// <summary>
        /// Iterates through all logical groups of the given part. Similar to <seealso cref="#forEachCharacteristic(PartEntries, CharacteristicOfSinglePartConsumer)"/>
        /// </summary>
        /// <param name="part"> </param>
        /// <param name="consumer"> </param>
        public virtual void ForEachGroup(PartEntries part, Action<GroupEntries> consumer) {
            SortedDictionary<GroupIndex, GroupEntries> groupsOfPart = _groupEntries.GetValueOrNull(part.Index);
            if (groupsOfPart != null) {
                groupsOfPart.ForEach((groupIndex, group) => {
                    consumer(group);
                });
            }
        }
        /// <summary>
        /// Iterates through all values.
        /// </summary>
        /// <param name="consumer"> </param>
        public virtual void ForEachValue(Action<PartEntries, CharacteristicEntries, ValueEntries> consumer) {
            _partEntries.ForEach((partIndex, part) => {
                var characteristicsOfPart = _characteristicEntries.GetValueOrNull(part.Index);
                if (characteristicsOfPart != null) {
                    characteristicsOfPart.ForEach((characteristicIndex, characteristic) => {
                        var valuesOfPart = _valueEntries.GetValueOrNull(part.Index);
                        if (valuesOfPart != null) {
                            var values = valuesOfPart.GetValueOrNull(characteristic.Index);
                            if (values != null) {
                                values.ForEach((valueIndex, value) => {
                                    consumer(part, characteristic, value);
                                });
                            }
                        }
                    });
                }
            });
        }
        /// <summary>
        /// Iterates through all values of the given part. Most of the time it will be used together with <seealso cref="#forEachPart(PartConsumer)"/>.
        /// <pre>
        /// model.forEachPart(part -> { 	 *     
        /// 
        ///     model.forEachValue(part, (characteristic, value) -> { 	 *         
        ///     });
        /// })
        /// </pre>
        /// </summary>
        /// <param name="part"> </param>
        /// <param name="consumer"> </param>
        public virtual void ForEachValue(PartEntries part, Action<CharacteristicEntries , ValueEntries> consumer) {
            throw new NotImplementedException();
            /*
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> characteristicsOfPart = CharacteristicEntries.GetValueOrNull(part.Index);
            if (characteristicsOfPart != null) {
                characteristicsOfPart.forEach((characteristicIndex, characteristic) => {
                    TreeMap<CharacteristicIndex, TreeMap<ValueIndex, ValueEntries>> valuesOfPart = ValueEntries.GetValueOrNull(part.Index);
                    if (valuesOfPart != null) {
                        TreeMap<ValueIndex, ValueEntries> values = valuesOfPart.get(characteristic.Index);
                        if (values != null) {
                            values.forEach((valueIndex, value) => {
                                consumer(characteristic, value);
                            });
                        }
                    }
                });
            }
            */
        }
        /// <summary>
        /// Iterates through all values of the given characteristic. Most of the time it will be used together with <seealso cref="#forEachCharacteristic(CharacteristicConsumer)"/>.
        /// <pre>
        /// model.forEachCharacteristic(part, characteristic -> { 	 *     
        /// 
        ///     model.forEachValue(part, characteristic, value -> { 	 *         
        ///     });
        /// })
        /// </pre>
        /// </summary>
        /// <param name="part"> </param>
        /// <param name="characteristic"> </param>
        /// <param name="consumer"> </param>
        public virtual void ForEachValue(PartEntries part, CharacteristicEntries characteristic, Action<ValueEntries> consumer) {
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> valuesOfPart = _valueEntries.GetValueOrNull(part.Index);
            if (valuesOfPart != null) {
                SortedDictionary<ValueIndex, ValueEntries> values = valuesOfPart.GetValueOrNull(characteristic.Index);
                if (values != null) {
                    values.ForEach((valueIndex, value) => {
                        consumer(value);
                    });
                }
            }
        }
        /// <summary>
        /// Removes all parts that do not match the given predicate.
        /// If a part is removed it's characteristics and values are also removed.
        /// </summary>
        /// <param name="predicate"> </param>
        public virtual void FilterParts(Func<PartEntries,bool> predicate) {
            throw new NotImplementedException();
            /*
            IEnumerator<KeyValuePair<PartIndex, PartEntries>> iterator = PartEntries.SetOfKeyValuePairs().GetEnumerator();
            while (iterator.MoveNext()) {
                KeyValuePair<PartIndex, PartEntries> entry = iterator.Current;
                PartIndex partIndex = entry.Key;
                PartEntries part = entry.Value;
                if (!predicate(part)) {
                    //JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
                    iterator.remove();

                    CharacteristicEntries.Remove(partIndex);
                    ValueEntries.Remove(partIndex);
                }
            }
            */
        }
        /// <summary>
        /// Removes all characteristics that do not match the given predicate.
        /// If a characteristic is removed it's values are also removed.
        /// </summary>
        /// <param name="predicate"> </param>
        public virtual void FilterCharacteristics(Func<PartEntries, CharacteristicEntries,bool> predicate) {
            throw new NotImplementedException();
            /*
            PartEntries.forEach((partIndex, part) => {
                TreeMap<CharacteristicIndex, CharacteristicEntries> characteristicsOfPart = CharacteristicEntries.GetValueOrNull(part.Index);
                if (characteristicsOfPart != null) {
                    Iterator<Entry<CharacteristicIndex, CharacteristicEntries>> iterator = characteristicsOfPart.entrySet().GetEnumerator();
                    while (iterator.hasNext()) {
                        Entry<CharacteristicIndex, CharacteristicEntries> entry = iterator.next();
                        CharacteristicIndex characteristicIndex = entry.Key;
                        CharacteristicEntries characteristic = entry.Value;
                        if (!predicate(part, characteristic)) {
                            iterator.remove();
                            removeValueEntries(characteristicIndex);
                        }
                    }
                }
            });
            */
        }
        /// <summary>
        /// Removes all characteristics of the given part that do not match the given predicate.
        /// If a characteristic is removed it's values are also removed.
        /// </summary>
        /// <param name="part"> </param>
        /// <param name="predicate"> </param>
        public virtual void FilterCharacteristics(PartEntries part, Func<CharacteristicEntries,bool> predicate) {
            throw new NotImplementedException();
            /*
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> characteristicsOfPart = CharacteristicEntries.GetValueOrNull(part.Index);
            if (characteristicsOfPart != null) {
                IEnumerator<KeyValuePair<CharacteristicIndex, CharacteristicEntries>> iterator = characteristicsOfPart.SetOfKeyValuePairs().GetEnumerator();
                while (iterator.MoveNext()) {
                    KeyValuePair<CharacteristicIndex, CharacteristicEntries> entry = iterator.Current;
                    CharacteristicIndex characteristicIndex = entry.Key;
                    CharacteristicEntries characteristic = entry.Value;
                    if (!predicate(characteristic)) {
                        //JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
                        iterator.remove();

                        removeValueEntries(characteristicIndex);
                    }
                }
            }
            */
        }
        /// <summary>
        /// Removes all groups that do not match the given predicate.
        /// </summary>
        /// <param name="predicate"> </param>
        public virtual void FilterGroups(Func<PartEntries, GroupEntries,bool> predicate) {
            throw new NotImplementedException();

            /*
            PartEntries.forEach((partIndex, part) => {
                TreeMap<GroupIndex, GroupEntries> groupsOfPart = GroupEntries.GetValueOrNull(part.Index);
                if (groupsOfPart != null) {
                    Iterator<Entry<GroupIndex, GroupEntries>> iterator = groupsOfPart.entrySet().GetEnumerator();
                    while (iterator.hasNext()) {
                        GroupEntries group = iterator.next().Value;
                        if (!predicate(part, group)) {
                            iterator.remove();
                        }
                    }
                }
            });
            */
        }
        /// <summary>
        /// Removes all groups of the given part that do not match the given predicate.
        /// </summary>
        /// <param name="part"> </param>
        /// <param name="predicate"> </param>
        public virtual void FilterGroups(PartEntries part, Func<GroupEntries,bool> predicate) {
            throw new NotImplementedException();
            /*
            SortedDictionary<GroupIndex, GroupEntries> groupsOfPart = GroupEntries.GetValueOrNull(part.Index);
            if (groupsOfPart != null) {
                IEnumerator<KeyValuePair<GroupIndex, GroupEntries>> iterator = groupsOfPart.SetOfKeyValuePairs().GetEnumerator();
                while (iterator.MoveNext()) {
                    GroupEntries group = iterator.Current.Value;
                    if (!predicate(group)) {
                        //JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
                        iterator.remove();
                    }
                }
            }*/
        }
        /// <summary>
        /// Removes all values that do not match the given predicate.
        /// </summary>
        /// <param name="predicate"> </param>
        public virtual void FilterValues(Func<PartEntries, CharacteristicEntries, ValueEntries,bool> predicate) {
            throw new NotImplementedException();
            /*
            PartEntries.forEach((partIndex, part) => {
                var characteristicsOfPart = CharacteristicEntries.GetValueOrNull(part.Index);
                if (characteristicsOfPart != null) {
                    characteristicsOfPart.forEach((characteristicIndex, characteristic) => {
                        var valuesOfPart = ValueEntries.GetValueOrNull(part.Index);
                        if (valuesOfPart != null) {
                            var values = valuesOfPart.get(characteristic.Index);
                            if (values != null) {
                                var iterator = values.entrySet().GetEnumerator();
                                while (iterator.hasNext()) {
                                    Entry<ValueIndex, ValueEntries> entry = iterator.next();
                                    ValueEntries value = entry.Value;
                                    if (!predicate(part, characteristic, value)) {
                                        iterator.remove();
                                    }
                                }
                            }
                        }
                    });
                }
            });
            */
        }
        /// <summary>
        /// Removes all values of the given part that do not match the given predicate.
        /// </summary>
        /// <param name="part"> </param>
        /// <param name="predicate"> </param>
        public virtual void FilterValues(PartEntries part, Func<CharacteristicEntries, ValueEntries,bool> predicate) {
            SortedDictionary<CharacteristicIndex, CharacteristicEntries> characteristicsOfPart = _characteristicEntries.GetValueOrNull(part.Index);
            if (characteristicsOfPart != null) {
                characteristicsOfPart.ForEach((characteristicIndex, characteristic) => {
                    var valuesOfPart = _valueEntries.GetValueOrNull(part.Index);
                    if (valuesOfPart != null) {
                        var values = valuesOfPart.GetValueOrNull(characteristic.Index);
                        if (values != null) {
                            var iterator = values.Where(v=>!predicate(characteristic,v.Value)).ToArray();
                            foreach (var pair in iterator) {
                                values.Remove(pair.Key);
                            }
                        }
                    }
                });
            }
        }
        /// <summary>
        /// Removes all values of the given characteristic that do not match the given predicate.
        /// </summary>
        /// <param name="part"> </param>
        /// <param name="characteristic"> </param>
        /// <param name="predicate"> </param>
        public virtual void FilterValues(PartEntries part, CharacteristicEntries characteristic, Func<CharacteristicEntries, ValueEntries,bool> predicate) {
            throw new NotImplementedException();
            /*
            SortedDictionary<CharacteristicIndex, SortedDictionary<ValueIndex, ValueEntries>> valuesOfPart = ValueEntries.GetValueOrNull(part.Index);
            if (valuesOfPart != null) {
                SortedDictionary<ValueIndex, ValueEntries> values = valuesOfPart.GetValueOrNull(characteristic.Index);
                if (values != null) {
                    IEnumerator<KeyValuePair<ValueIndex, ValueEntries>> iterator = values.SetOfKeyValuePairs().GetEnumerator();
                    while (iterator.MoveNext()) {
                        KeyValuePair<ValueIndex, ValueEntries> entry = iterator.Current;
                        ValueEntries value = entry.Value;
                        if (!predicate(characteristic, value)) {
                            //JAVA TO C# CONVERTER TODO TASK: .NET enumerators are read-only:
                            iterator.remove();
                        }
                    }
                }
            }
            */
        }
        /// <summary>
        /// Finds value of the given K-key from any part / characteristic / value.
        /// <para>
        /// There is no guarantee from which part / characteristic / value this K-key value will be taken (whether from the first or other).
        /// </para>
        /// </summary>
        /// <param name="key"> any K-key of part / characteristic / value
        /// @return </param>
        /// <exception cref="IllegalArgumentException"> if the K-key is not for part / characteristic / value lavel. </exception>
        public virtual object GetAnyValueOf(KKey key) {
            throw new NotImplementedException();
            /*
            if (key.IsPartLevel) {
                return PartEntries.Values.First().Select((entries) => entries.getValue(key)).orElse(null);
            } else if (key.IsCharacteristicLevel) {
                return CharacteristicEntries.Values.First().Select((entriesOfPart) => {
                    return entriesOfPart.values().First().Select((entries) => entries.getValue(key)).orElse(null);
                }).orElse(null);
            } else if (key.IsGroupLevel) {
                return GroupEntries.Values.First().Select((entriesOfPart) => {
                    return entriesOfPart.values().First().Select((entries) => entries.getValue(key)).orElse(null);
                }).orElse(null);
            } else if (key.IsValueLevel) {
                return ValueEntries.Values.First().Select((entriesOfPart) => {
                    return entriesOfPart.values().First().Select((entriesOfCharacteristic) => {
                        return entriesOfCharacteristic.values().First().Select((entries) => entries.getValue(key)).orElse(null);
                    }).orElse(null);
                }).orElse(null);
            } else {
                throw new System.ArgumentException(string.Format("Invalid k-key {0}. Value can be obtained only for part / characteristic / value keys.", key));
            }*/
        }
        /// <summary>
        /// Normalize the AQDEF content.
        /// <ul>
        /// <li>Apply all /0 K-keys on all parts / characteristics / values and then
        /// remove them from object model.</li>
        /// <li>Complement the hierarchy so there are no nodes/characteristics wihout a
        /// parent part node. This may happen when hierarchy was created from simple
        /// characteristics grouping (K2030/K2031).</li>
        /// </ul>
        /// </summary>
        public virtual void Normalize() {
            PartEntries entriesForAllParts = RemovePartEntries(PartIndex.Of(0));
            if (entriesForAllParts!=null && entriesForAllParts.Any()) {
                if (PartIndexes.Count == 0) {
                    PartIndex partIndex = PartIndex.Of(1);
                    _partEntries[partIndex] = (PartEntries) entriesForAllParts.WithIndex(partIndex);
                } else {
                    ForEachPart((part) => {
                        part.PutAll(entriesForAllParts.WithIndex(part.Index).Values, false);
                    });
                }
            }

            CharacteristicIndex indexForAllCharacteristicsOfAllParts = CharacteristicIndex.Of(PartIndex.Of(0), 0);
            CharacteristicEntries entriesForAllCharacteristicsOfAllParts = new CharacteristicEntries(indexForAllCharacteristicsOfAllParts);
            CharacteristicEntries characteristicEntriesForAllCharacteristicsOfAllParts = RemoveCharacteristicEntries(indexForAllCharacteristicsOfAllParts);
            if (characteristicEntriesForAllCharacteristicsOfAllParts!=null && characteristicEntriesForAllCharacteristicsOfAllParts.Any()) {
                entriesForAllCharacteristicsOfAllParts.PutAll(characteristicEntriesForAllCharacteristicsOfAllParts.Values, false);
            }
            IList<ValueEntries> entriesForAllValuesOfAllParts = RemoveValueEntries(indexForAllCharacteristicsOfAllParts);
            //JAVA TO C# CONVERTER TODO TASK: Most Java stream collectors are not converted by Java to C# Converter:
            var entriesForAllValuesByValueIndex = entriesForAllValuesOfAllParts.GroupBy(e => e.Index.Index)
                .ToDictionary(g => g.Key, g => g.ToArray());
            ForEachPart((part) => {
                CharacteristicIndex indexForAllCharacteristics = CharacteristicIndex.Of(part.Index, 0);
                CharacteristicEntries entriesForAllCharacteristics = RemoveCharacteristicEntries(indexForAllCharacteristics);
                if (entriesForAllCharacteristics!=null && entriesForAllCharacteristics.Any()) {
                    entriesForAllCharacteristicsOfAllParts.PutAll(entriesForAllCharacteristics.Values, false);
                }
            });
            ForEachCharacteristic((part, characteristic) => {
                characteristic.PutAll(entriesForAllCharacteristicsOfAllParts.WithIndex(characteristic.Index).Values, false);
                ForEachValue(part, characteristic, (value) => {
                    var entriesForValueIndex = entriesForAllValuesByValueIndex.GetValueOrNull(value.Index.Index);
                    if (entriesForValueIndex != null) {
                        foreach (ValueEntries valueEntries in entriesForValueIndex) {
                            value.PutAll(valueEntries.WithIndex(value.Index).Values, false);
                        }
                    }
                });
            });

            _hierarchyRenamed = _hierarchyRenamed.Normalize(this);
        }

        /// <summary>
        /// Returns total number of characteristics of all parts in this object model
        /// 
        /// @return
        /// </summary>
        public virtual int CharacteristicCount {
            get {
                var characteristicCount = 0;
               ForEachCharacteristic((part, characteristic) => characteristicCount++);
               return characteristicCount;
            }
        }
        /// <summary>
        /// Returns total number of values of all parts and characteristics in this object model
        /// 
        /// @return
        /// </summary>
        public virtual int ValueCount {
            get {
                int count = 0;
                ForEachValue((part, characteristic, value) => count++);
                return count;
            }
        }
        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((_characteristicEntries == null) ? 0 : _characteristicEntries.GetHashCode());
            result = prime * result + ((_groupEntries == null) ? 0 : _groupEntries.GetHashCode());
            result = prime * result + ((_hierarchyRenamed == null) ? 0 : _hierarchyRenamed.GetHashCode());
            result = prime * result + ((_partEntries == null) ? 0 : _partEntries.GetHashCode());
            result = prime * result + ((_valueEntries == null) ? 0 : _valueEntries.GetHashCode());
            return result;
        }
        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is AqdefObjectModel)) {
                return false;
            }
            AqdefObjectModel other = (AqdefObjectModel)obj;
            if (_characteristicEntries == null) {
                if (other._characteristicEntries != null) {
                    return false;
                }
            } else if (!_characteristicEntries.Equals(other._characteristicEntries)) {
                return false;
            }
            if (_groupEntries == null) {
                if (other._groupEntries != null) {
                    return false;
                }
            } else if (!_groupEntries.Equals(other._groupEntries)) {
                return false;
            }
            if (_hierarchyRenamed == null) {
                if (other._hierarchyRenamed != null) {
                    return false;
                }
            } else if (!_hierarchyRenamed.Equals(other._hierarchyRenamed)) {
                return false;
            }
            if (_partEntries == null) {
                if (other._partEntries != null) {
                    return false;
                }
            } else if (!_partEntries.Equals(other._partEntries)) {
                return false;
            }
            if (_valueEntries == null) {
                if (other._valueEntries != null) {
                    return false;
                }
            } else if (!_valueEntries.Equals(other._valueEntries)) {
                return false;
            }
            return true;
        }



        public virtual AqdefHierarchy Hierarchy {
            get {
                return _hierarchyRenamed;
            }
            set {
                this._hierarchyRenamed = value;
            }
        }



        public delegate void PartConsumer(PartEntries part);
        public delegate void CharacteristicConsumer(PartEntries part, CharacteristicEntries characteristic);
        public delegate void CharacteristicOfSinglePartConsumer(CharacteristicEntries characteristic);
        public delegate void GroupConsumer(PartEntries part, GroupEntries characteristic);
        public delegate void GroupOfSinglePartConsumer(GroupEntries characteristic);
        public delegate void ValueConsumer(PartEntries part, CharacteristicEntries characteristic, ValueEntries value);
        public delegate void ValueOfSinglePartConsumer(CharacteristicEntries characteristic, ValueEntries value);
        public delegate void ValueOfSingleCharacteristicConsumer(ValueEntries value);
        public delegate bool PartPredicate(PartEntries part);
        public delegate bool CharacteristicPredicate(PartEntries part, CharacteristicEntries characteristic);
        public delegate bool CharacteristicOfSinglePartPredicate(CharacteristicEntries characteristic);
        public delegate bool GroupPredicate(PartEntries part, GroupEntries group);
        public delegate bool GroupOfSinglePartPredicate(GroupEntries group);
        public delegate bool ValuePredicate(PartEntries part, CharacteristicEntries characteristic, ValueEntries value);
        public delegate bool ValueOfSinglePartPredicate(CharacteristicEntries characteristic, ValueEntries value);
        public delegate bool ValueOfSingleCharacteristicPredicate(ValueEntries value);

    }
}
