using System.Collections.Generic;
using AQDEF.Sharp.Models;

namespace AQDEF.Sharp.Models {
    public abstract class Entries<E, I> : SortedDictionary<KKey, E>, IHasKKeyValues where E : AbstractEntry<I> {
        private readonly I _index;

        public Entries(I index) : base() {
            this._index = index;
        }

        public virtual void put(string key, object value) {
            this.Add(KKey.Of(key), value as E);
        }

        public virtual void put(KKey key, object value) {
            this.Add(newEntry(key, _index, value));
        }

        public virtual void Add(E entry) {
            KKey key = entry.Key;
            this.Add(key, entry);
        }

        public new void Add(KKey key, E entry) {
            if (!object.Equals(_index, entry.Index)) {
                throw new System.ArgumentException("Index of the entry (" + entry.Index + ") does not match entries index (" + _index + ")");
            }
            base.Add(key, entry);
        }
        public virtual void putAll(IEnumerable<E> entries, bool overwriteExisting) {
            foreach (var entry in entries) {
                if (overwriteExisting) {
                    this.Add(entry.Key, entry);
                } else {
                    this.putIfAbsent(entry.Key, entry);
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
        public T getValue<T>(string key) {
            return getValue<T>(KKey.Of(key));
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Override @SuppressWarnings("unchecked") public <T> T getValue(cz.diribet.aqdef.KKey key)
        public T getValue<T>(KKey key) {
            E entry;
            if (this.TryGetValue(key, out entry)) {
                return (T) entry.Value;
            }
            return default(T);
        }

        public virtual I Index {
            get {
                return _index;
            }
        }

        protected internal abstract E newEntry(KKey key, I index, object value);


        /// <summary>
        /// Creates a copy of this entries with a given index.
        /// </summary>
        /// <param name="index">
        /// @return </param>
        public abstract Entries<E, I> withIndex(I index);


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
            if (!(obj is Entries<E,I>)) {
                return false;
            }
            var other = (Entries<E, I>) obj;
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