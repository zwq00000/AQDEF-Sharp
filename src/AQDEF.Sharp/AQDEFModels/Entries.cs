using System.Collections.Generic;
using AQDEF.Sharp.Models;

namespace AQDEF.Sharp.Models {
    public abstract class Entries<TE, T> : SortedDictionary<KKey, TE>, IHasKKeyValues where TE : AbstractEntry<T> {
        private readonly T _index;

        public Entries(T index) : base() {
            this._index = index;
        }

        public virtual void Put(string key, object value) {
            this.Add(KKey.Of(key), value as TE);
        }

        public virtual void Put(KKey key, object value) {
            this.Add(NewEntry(key, _index, value));
        }

        public virtual void Add(TE entry) {
            KKey key = entry.Key;
            this.Add(key, entry);
        }

        public new void Add(KKey key, TE entry) {
            if (!object.Equals(_index, entry.Index)) {
                throw new System.ArgumentException("Index of the entry (" + entry.Index + ") does not match entries index (" + _index + ")");
            }
            base.Add(key, entry);
        }
        public virtual void PutAll(IEnumerable<TE> entries, bool overwriteExisting) {
            foreach (var entry in entries) {
                if (overwriteExisting) {
                    this.Add(entry.Key, entry);
                } else {
                    this.PutIfAbsent(entry.Key, entry);
                }
            }
        }
        /*
        public virtual void putAll<T1>(IDictionary<T1> entries, bool overwriteExisting) where T1 : KKey {
            this.putAll(entries.Values, overwriteExisting);
        }

        public virtual T getValue<T>(string key) {
            return getValue(KKey.Of(key));
        }
        public virtual T getValue<T>(string key, T defaultValue) {
            return getValue(KKey.Of(key), defaultValue);
        }

        public virtual T getValue<T>(KKey key, T defaultValue) {
            T value = getValue(key);
            return value == default(T) ? defaultValue : value;
        }*/
        public T GetValue<T>(string key) {
            return GetValue<T>(KKey.Of(key));
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Override @SuppressWarnings("unchecked") public <T> T getValue(cz.diribet.aqdef.KKey key)
        public T GetValue<T>(KKey key) {
            TE entry;
            if (this.TryGetValue(key, out entry)) {
                return (T) entry.Value;
            }
            return default(T);
        }

        public virtual T Index {
            get {
                return _index;
            }
        }

        protected internal abstract TE NewEntry(KKey key, T index, object value);


        /// <summary>
        /// Creates a copy of this entries with a given index.
        /// </summary>
        /// <param name="index">
        /// @return </param>
        public abstract Entries<TE, T> WithIndex(T index);


        public override int GetHashCode() {
            const int prime = 31;
            int result = base.GetHashCode();
            result = prime * result + ((_index == null) ? 0 : _index.GetHashCode());
            return result;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("rawtypes") @Override public boolean equals(Object obj)
        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (!base.Equals(obj)) {
                return false;
            }
            if (!(obj is Entries<TE,T>)) {
                return false;
            }
            var other = (Entries<TE, T>) obj;
            if (_index == null) {
                if (other._index != null) {
                    return false;
                }
            } else if (!_index.Equals(other._index)) {
                return false;
            }
            return true;
        }
    }
}