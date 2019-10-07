namespace AQDEF.Sharp.Models {
    public class CharacteristicEntry : AbstractEntry<CharacteristicIndex> {
        public CharacteristicEntry(KKey key, CharacteristicIndex index, object value) : base((KKey) ValidateKey(key), index, value) {
        }

        private static KKey ValidateKey(KKey key) {
            if (!key.IsCharacteristicLevel) {
                throw new System.ArgumentException("K-Key of characteristic type expected, but found: " + key);
            }
            return key;
        }
    }
}