namespace AQDEF.Sharp.AQDEFModels {
    public class PartEntry : AbstractEntry<PartIndex> {
        public PartEntry(KKey key, PartIndex index, object value) : base((KKey) validateKey(key), index, value) {
        }

        private static KKey validateKey(KKey key) {
            if (!key.IsPartLevel) {
                throw new System.ArgumentException("K-Key of part type expected, but found: " + key);
            }
            return key;
        }
    }
}