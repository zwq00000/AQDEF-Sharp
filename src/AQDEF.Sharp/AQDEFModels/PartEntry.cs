namespace AQDEF.Sharp.Models {
    public class PartEntry : AbstractEntry<PartIndex> {
        public PartEntry(KKey key, PartIndex index, object value) : base((KKey) ValidateKey(key), index, value) {
        }

        private static KKey ValidateKey(KKey key) {
            if (!key.IsPartLevel) {
                throw new System.ArgumentException("K-Key of part type expected, but found: " + key);
            }
            return key;
        }
    }
}