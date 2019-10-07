using System.Collections.Generic;
using System.Linq;

namespace AQDEF.Sharp.AQDEFModels {
    public class CharacteristicEntries : Entries<CharacteristicEntry, CharacteristicIndex> {
        public CharacteristicEntries(CharacteristicIndex index) : base(index) {
        }
        public override Entries<CharacteristicEntry, CharacteristicIndex> withIndex(CharacteristicIndex index) {
            CharacteristicEntries copy = new CharacteristicEntries(index);
            IList<CharacteristicEntry> entriesCopy = Enumerable.Select<CharacteristicEntry, CharacteristicEntry>(Values, e => new CharacteristicEntry(e.Key, index, e.Value)).ToList();
            copy.putAll(entriesCopy, true);
            return copy;
        }
        protected internal override CharacteristicEntry newEntry(KKey key, CharacteristicIndex index, object value) {
            return new CharacteristicEntry(key, index, value);
        }
    }
}