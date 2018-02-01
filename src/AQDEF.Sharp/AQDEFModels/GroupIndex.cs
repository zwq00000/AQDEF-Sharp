using System;

namespace AQDEF.Sharp.Models {
    public class GroupIndex : IComparable<GroupIndex> {
        private readonly PartIndex PartIndex_Renamed;
        private readonly int? GroupIndex_Renamed;

        private GroupIndex(PartIndex partIndex, int? groupIndex) {
            this.PartIndex_Renamed = partIndex;
            this.GroupIndex_Renamed = groupIndex;
        }

        public virtual PartIndex PartIndex {
            get {
                return PartIndex_Renamed;
            }
        }

        public virtual int? getGroupIndex() {
            return GroupIndex_Renamed;
        }

        public static GroupIndex of(PartIndex partIndex, int? groupIndex) {
            return new GroupIndex(partIndex, groupIndex);
        }

        public static GroupIndex of(int? partIndex, int? groupIndex) {
            return of(PartIndex.of(partIndex), groupIndex);
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((PartIndex_Renamed == null) ? 0 : PartIndex_Renamed.GetHashCode());
            result = prime * result + ((GroupIndex_Renamed == null) ? 0 : GroupIndex_Renamed.GetHashCode());
            return result;
        }

        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is GroupIndex)) {
                return false;
            }
            GroupIndex other = (GroupIndex)obj;
            if (PartIndex_Renamed == null) {
                if (other.PartIndex_Renamed != null) {
                    return false;
                }
            } else if (!PartIndex_Renamed.Equals(other.PartIndex_Renamed)) {
                return false;
            }
            if (GroupIndex_Renamed == null) {
                if (other.GroupIndex_Renamed != null) {
                    return false;
                }
            } else if (!GroupIndex_Renamed.Equals(other.GroupIndex_Renamed)) {
                return false;
            }
            return true;
        }

        public virtual int CompareTo(GroupIndex o) {
            if (this == o) {
                return 0;
            }

            int compareResultPart = this.PartIndex_Renamed.CompareTo(o.PartIndex_Renamed);

            if (compareResultPart != 0) {
                return compareResultPart;
            } else {
                if (this.GroupIndex_Renamed == o.GroupIndex_Renamed) {
                    return 0;
                }
                if (this.GroupIndex_Renamed == null) {
                    return -1;
                }
                if (o.GroupIndex_Renamed == null) {
                    return 1;
                }

                return this.GroupIndex_Renamed.Value.CompareTo(o.GroupIndex_Renamed);
            }
        }

        public override string ToString() {
            string result = "";
            if (PartIndex_Renamed != null) {
                result += PartIndex_Renamed.ToString();
            }

            result += "/";

            if (GroupIndex_Renamed != null) {
                result += GroupIndex_Renamed;
            }

            return result;
        }

    }
}