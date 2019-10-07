using System.Collections.Generic;
using System.Linq;
using AQDEF.Sharp.Models;

namespace AQDEF.Sharp.AQDEFModels {
    public class ValueEntries : Entries<ValueEntry, ValueIndex> {
        public ValueEntries(ValueIndex index) : base(index) {
        }
        public override Entries<ValueEntry, ValueIndex> withIndex(ValueIndex index) {
            ValueEntries copy = new ValueEntries(index);
            IList<ValueEntry> entriesCopy = Enumerable.Select<ValueEntry, ValueEntry>(Values, e => new ValueEntry(e.Key, index, e.Value)).ToList();
            copy.putAll(entriesCopy, true);
            return copy;
        }
        protected internal override ValueEntry newEntry(KKey key, ValueIndex index, object value) {
            return new ValueEntry(key, index, value);
        }
    }
}