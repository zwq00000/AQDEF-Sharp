using System.Linq;

namespace AQDEF.Sharp.AQDEFModels {
        public class PartEntries : Entries<PartEntry, PartIndex> {
            public PartEntries(PartIndex index) : base(index) {
            }

            public override Entries<PartEntry, PartIndex> withIndex(PartIndex index) {
                PartEntries copy = new PartEntries(index);
                var entriesCopy = Values.Select(e => new PartEntry(e.Key, index, e.Value));
                copy.putAll(entriesCopy, true);
                return copy;
            }
            protected internal override PartEntry newEntry(KKey key, PartIndex index, object value) {
                return new PartEntry(key, index, value);
            }
        }
}