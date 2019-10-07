using System.Collections.Generic;
using System.Linq;

namespace AQDEF.Sharp.AQDEFModels {
    public class GroupEntries : Entries<GroupEntry, GroupIndex> {
        public GroupEntries(GroupIndex index) : base(index) {
        }
        public override Entries<GroupEntry, GroupIndex> withIndex(GroupIndex index) {
            GroupEntries copy = new GroupEntries(index);
            IList<GroupEntry> entriesCopy = Enumerable.Select<GroupEntry, GroupEntry>(Values, e => new GroupEntry(e.Key, index, e.Value)).ToList();
            copy.putAll(entriesCopy, true);
            return copy;
        }
        protected internal override GroupEntry newEntry(KKey key, GroupIndex index, object value) {
            return new GroupEntry(key, index, value);
        }
    }
}