namespace AQDEF.Sharp.AQDEFModels {
    public class GroupEntry : AbstractEntry<GroupIndex> {
        public GroupEntry(KKey key, GroupIndex index, object value) : base((KKey) ValidateKey(key), index, value) {
        }

        private static KKey ValidateKey(KKey key) {
            if (!key.IsGroupLevel) {
                throw new System.ArgumentException("K-Key of group type expected, but found: " + key);
            }
            return key;
        }
    }
}