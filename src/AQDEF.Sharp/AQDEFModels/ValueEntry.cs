namespace AQDEF.Sharp.AQDEFModels {
    public class ValueEntry : AbstractEntry<ValueIndex> {
        public ValueEntry(KKey key, ValueIndex index, object value) : base((KKey) ValidateKey(key), index, value) {
        }

        private static KKey ValidateKey(KKey key) {
            if (!key.IsValueLevel) {
                throw new System.ArgumentException("K-Key of value type expected, but found: " + key);
            }
            return key;
        }
    }
}