using System.Collections.Generic;
using System.Linq;

namespace AQDEF.Sharp.Models {
    public class ValueEntries : Entries<ValueEntry, ValueIndex> {
        public ValueEntries(ValueIndex index) : base(index) {
        }
        public override Entries<ValueEntry, ValueIndex> WithIndex(ValueIndex index) {
            ValueEntries copy = new ValueEntries(index);
            IList<ValueEntry> entriesCopy = Enumerable.Select<ValueEntry, ValueEntry>(Values, e => new ValueEntry(e.Key, index, e.Value)).ToList();
            copy.PutAll(entriesCopy, true);
            return copy;
        }
        protected internal override ValueEntry NewEntry(KKey key, ValueIndex index, object value) {
            return new ValueEntry(key, index, value);
        }
    }
}