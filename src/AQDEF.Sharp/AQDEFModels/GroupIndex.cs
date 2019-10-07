using System;

namespace AQDEF.Sharp.Models {
    public class GroupIndex : IComparable<GroupIndex> {
        private GroupIndex(PartIndex partIndex, int? groupIndex) {
            this.PartIndex = partIndex;
            this.Index = groupIndex;
        }

        public PartIndex PartIndex { get; }

        public virtual int? Index { get; }

        public static GroupIndex Of(PartIndex partIndex, int? groupIndex) {
            return new GroupIndex(partIndex, groupIndex);
        }

        public static GroupIndex Of(int? partIndex, int? groupIndex) {
            return Of(PartIndex.Of(partIndex), groupIndex);
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((PartIndex == null) ? 0 : PartIndex.GetHashCode());
            result = prime * result + ((Index == null) ? 0 : Index.GetHashCode());
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
            if (PartIndex == null) {
                if (other.PartIndex != null) {
                    return false;
                }
            } else if (!PartIndex.Equals(other.PartIndex)) {
                return false;
            }
            if (Index == null) {
                if (other.Index != null) {
                    return false;
                }
            } else if (!Index.Equals(other.Index)) {
                return false;
            }
            return true;
        }

        public virtual int CompareTo(GroupIndex o) {
            if (this == o) {
                return 0;
            }

            int compareResultPart = this.PartIndex.CompareTo(o.PartIndex);

            if (compareResultPart != 0) {
                return compareResultPart;
            } else {
                if (this.Index == o.Index) {
                    return 0;
                }
                if (this.Index == null) {
                    return -1;
                }
                if (o.Index == null) {
                    return 1;
                }

                return this.Index.Value.CompareTo(o.Index);
            }
        }

        public override string ToString() {
            string result = "";
            if (PartIndex != null) {
                result += PartIndex.ToString();
            }

            result += "/";

            if (Index != null) {
                result += Index;
            }

            return result;
        }

    }
}