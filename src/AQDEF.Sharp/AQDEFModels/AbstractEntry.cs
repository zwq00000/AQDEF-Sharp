namespace AQDEF.Sharp.AQDEFModels {
    public abstract class AbstractEntry<TI> {
        protected AbstractEntry(KKey key, TI index, object value) {
            this.Key = key;
            this.Index = index;
            this.Value = value;
        }

        public KKey Key { get; private set; }
        public TI Index { get; private set; }
        public object Value { get; private set; }
        /// <summary>
        /// Whether this entry has given key.
        /// </summary>
        /// <param name="otherkey">
        /// @return </param>
        public virtual bool HasKey(KKey otherkey) {
            return Key.Equals(otherkey);
        }
        public override string ToString() {
            if (Value == null) {
                return "null";
            } else {
                return Value.ToString();
            }
        }
        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((Index == null) ? 0 : Index.GetHashCode());
            result = prime * result + ((Key == null) ? 0 : Key.GetHashCode());
            result = prime * result + ((Value == null) ? 0 : Value.GetHashCode());
            return result;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("rawtypes") @Override public boolean equals(Object obj)
        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }

            if (!(obj is AbstractEntry<TI>)) {
                return false;
            }
            var other = (AbstractEntry<TI>)obj;
            if (Index == null) {
                if (other.Index != null) {
                    return false;
                }
            } else if (!Index.Equals(other.Index)) {
                return false;
            }
            if (Key == null) {
                if (other.Key != null) {
                    return false;
                }
            } else if (!Key.Equals(other.Key)) {
                return false;
            }
            if (Value == null) {
                if (other.Value != null) {
                    return false;
                }
            } else if (!Value.Equals(other.Value)) {
                return false;
            }
            return true;
        }
    }
}