using System.Collections.Generic;
using System.Linq;

namespace AQDEF.Sharp.Models {
        public class PartEntries : Entries<PartEntry, PartIndex> {
            public PartEntries(PartIndex index) : base(index) {
            }

            public override Entries<PartEntry, PartIndex> WithIndex(PartIndex index) {
                PartEntries copy = new PartEntries(index);
                var entriesCopy = Values.Select(e => new PartEntry(e.Key, index, e.Value));
                copy.PutAll(entriesCopy, true);
                return copy;
            }
            protected internal override PartEntry NewEntry(KKey key, PartIndex index, object value) {
                return new PartEntry(key, index, value);
            }
        }
}