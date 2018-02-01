﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQDEF.Sharp;
using AQDEF.Sharp.Models;

namespace AQDEF.Models {

    #region  interfaces

    #endregion

    public class AqdefModel : BaseEnties {
        private readonly EntiesCollection<PartEntry> _partEntries;

        public AqdefModel() : base(0) {
            this.SharedEnties = new SharedEntities(KKey.KKeyLevel.CHARACTERISTIC | KKey.KKeyLevel.PART | KKey.KKeyLevel.VALUE);
            _partEntries = new EntiesCollection<PartEntry>(KKey.KKeyLevel.PART, i => new PartEntry(i)) {
                SharedEnties = this.SharedEnties
            };
        }

        /// <summary>
        /// 文件中的参数总数
        /// </summary>
        public short CharacteristicsCount {
            get { return base.GetValue<short>("K0100"); }
        }

        public EntiesCollection<PartEntry> Parts => _partEntries;

        public override KKey.KKeyLevel Level => KKey.KKeyLevel.VALUE;

        /// <summary>
        /// 共享内容
        /// </summary>
        internal class SharedEntities : BaseEnties {

            public SharedEntities(KKey.KKeyLevel level) : base(0) {
                this.Level = level;
            }

            public override KKey.KKeyLevel Level { get; }
        }

        public virtual PartEntry GetPartEntries(int index) {
            return this.Parts[index];
        }
        public virtual CharacteristicEntry GetCharacteristicEntries(int partIndex, int characteristicIndex) {
            var part =  Parts[partIndex];
            return part?.Characteristics[characteristicIndex];
        }

        public virtual ValueEntry GetValueEntries(int partIndex, int characteristicIndex, int valueIndex) {
            var characteristic = GetCharacteristicEntries(partIndex, characteristicIndex);
            return characteristic?.Values[valueIndex];
        }
    }

    public class EntiesCollection<TEntities> : IEnumerable<TEntities> where TEntities : BaseEnties {
        private readonly IDictionary<int, TEntities> _innerEntieses = new Dictionary<int, TEntities>();
        private readonly KKey.KKeyLevel _level;
        private readonly Func<int, TEntities> _entitiesFactory;

        public EntiesCollection(KKey.KKeyLevel level, Func<int, TEntities> entiiesCreator) {
            this._level = level;
            _entitiesFactory = entiiesCreator;
        }

        /// <summary>
        /// 共享条目
        /// </summary>
        internal BaseEnties SharedEnties { get; set; }

        public TEntities this[int index] {
            get {
                if (index == 0) {
                    return null;
                }
                TEntities enties;
                if (!_innerEntieses.TryGetValue(index, out enties)) {
                    enties = _entitiesFactory(index);
                    enties.SharedEnties = this.SharedEnties;
                    _innerEntieses.Add(index, enties);
                }
                return enties;
            }
        }

        public object GetValue(string key) {
            if (SharedEnties.Entries.Any()) {
                return this.SharedEnties.GetValue(key);
            } else {
                var enties = this.FirstOrDefault();
                if (enties != null) {
                    return enties.GetValue(key);
                }
            }
            return null;
        }

        public virtual void Add(IKKeyEntry entry) {
            if (entry.Key.Level != _level) {
                throw new ArgumentException($"Entry Level Is Must {_level}");
            }
            if (entry.Index == 0) {
                SharedEnties.Add(entry);
            } else {
                var enties = this[entry.Index];
                enties.Add(entry);
            }
        }

        #region Implementation of IEnumerable

        /// <summary>返回一个循环访问集合的枚举器。</summary>
        /// <returns>可用于循环访问集合的 <see cref="T:System.Collections.Generic.IEnumerator`1" />。</returns>
        public IEnumerator<TEntities> GetEnumerator() {
            foreach (var entitiese in this._innerEntieses.Values) {
                yield return entitiese;
            }
        }

        /// <summary>返回一个循环访问集合的枚举器。</summary>
        /// <returns>可用于循环访问集合的 <see cref="T:System.Collections.IEnumerator" /> 对象。</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }


    public class PartEntry : BaseEnties {
        private EntiesCollection<CharacteristicEntry> _characteristics;

        public PartEntry(int index) : base(index) {

        }

        public PartEntry(IKKeyEntry entry) : base(entry) {
        }

        /// <summary>
        /// Part number
        /// </summary>
        /// <returns></returns>
        public string PartNumber {
            get {
                return base.GetValue<string>("K1001");
            }
            set {
                SetValue("K1001", value);
            }
        }

        /// <summary>
        /// Part description
        /// </summary>
        /// <returns></returns>
        public string Description {
            get {
                return base.GetValue<string>("K1002");
            }
            set {
                SetValue("K1002", value);
            }
        }

        #region Overrides of BaseEnties

        /// <summary>
        /// entry Level
        /// </summary>
        public override KKey.KKeyLevel Level => KKey.KKeyLevel.PART;

        #endregion


        public EntiesCollection<CharacteristicEntry> Characteristics {
            get {
                return _characteristics ?? (_characteristics = new EntiesCollection<CharacteristicEntry>(
                           KKey.KKeyLevel.CHARACTERISTIC,
                           i => new CharacteristicEntry(i)) {
                    SharedEnties = this.SharedEnties
                });
            }
        }
    }

    public class CharacteristicEntry : BaseEnties {

        private EntiesCollection<ValueEntry> _valueEnties;

        private readonly BaseEnties _valueSharedEnties = new AqdefModel.SharedEntities(KKey.KKeyLevel.VALUE);


        public CharacteristicEntry(int index) : base(index) {
        }

        public CharacteristicEntry(IKKeyEntry entry) : base(entry) {
        }

        #region Overrides of BaseEnties

        /// <summary>
        /// entry Level
        /// </summary>
        public override KKey.KKeyLevel Level => KKey.KKeyLevel.CHARACTERISTIC | KKey.KKeyLevel.VALUE;

        #endregion


        public override void Add(IKKeyEntry entry) {
            base.ThrowIfNotCheckLevel(entry.Key.Level);
            if (entry.Key.Level == KKey.KKeyLevel.VALUE) {
                Values.Add(entry);
            } else {
                if (entry.Index == 0) {
                    this.SharedEnties.Add(entry);
                } else {
                    base.Add(entry);
                }
            }
        }

        public EntiesCollection<ValueEntry> Values {
            get {
                if (_valueEnties == null) {
                    _valueEnties = new EntiesCollection<ValueEntry>(
                        KKey.KKeyLevel.VALUE,
                        i => new ValueEntry(i)) {
                        SharedEnties = _valueSharedEnties
                    };
                }
                return _valueEnties;
            }
        }
    }

    public class ValueEntry : BaseEnties {
        #region Overrides of BaseEnties

        /// <summary>
        /// entry Level
        /// </summary>
        public override KKey.KKeyLevel Level => KKey.KKeyLevel.VALUE;

        #endregion

        public ValueEntry(int index) : base(index) {
        }

        public ValueEntry(IKKeyEntry entry) : base(entry) {
        }
    }
}
