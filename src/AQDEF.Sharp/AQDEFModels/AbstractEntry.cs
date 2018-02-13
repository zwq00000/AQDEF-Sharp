namespace AQDEF.Sharp.Models {
    public abstract class AbstractEntry<TI> {
        private readonly KKey _key;
        private readonly TI _index;
        private readonly object _value;

        protected AbstractEntry(KKey key, TI index, object value) {
            this._key = key;
            this._index = index;
            this._value = value;
        }

        public KKey Key {
            get {
                return _key;
            }
        }
        public TI Index {
            get {
                return _index;
            }
        }
        public object Value {
            get {
                return _value;
            }
        }
        /// <summary>
        /// Whether this entry has given key.
        /// </summary>
        /// <param name="otherkey">
        /// @return </param>
        public virtual bool HasKey(KKey otherkey) {
            return _key.Equals(otherkey);
        }
        public override string ToString() {
            if (_value == null) {
                return "null";
            } else {
                return _value.ToString();
            }
        }
        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((_index == null) ? 0 : _index.GetHashCode());
            result = prime * result + ((_key == null) ? 0 : _key.GetHashCode());
            result = prime * result + ((_value == null) ? 0 : _value.GetHashCode());
            return result;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("rawtypes") @Override public boolean equals(Object obj)
        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is AbstractEntry<TI>)) {
                return false;
            }
            var other = (AbstractEntry<TI>)obj;
            if (_index == null) {
                if (other._index != null) {
                    return false;
                }
            } else if (!_index.Equals(other._index)) {
                return false;
            }
            if (_key == null) {
                if (other._key != null) {
                    return false;
                }
            } else if (!_key.Equals(other._key)) {
                return false;
            }
            if (_value == null) {
                if (other._value != null) {
                    return false;
                }
            } else if (!_value.Equals(other._value)) {
                return false;
            }
            return true;
        }
    }
}