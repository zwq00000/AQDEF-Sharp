using System;

namespace AQDEF.Sharp.Models {
    /// <summary>
    /// @author Vlastimil Dolejs
    /// 
    /// </summary>
    public class PartIndex : IComparable<PartIndex> {
        private PartIndex(int? index) {
            this.Index = index;
        }

        public virtual int? Index { get; }

        public static PartIndex Of(int? index) {
            return new PartIndex(index);
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
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
            if (!(obj is PartIndex)) {
                return false;
            }
            PartIndex other = (PartIndex)obj;
            if (Index == null) {
                if (other.Index != null) {
                    return false;
                }
            } else if (!Index.Equals(other.Index)) {
                return false;
            }
            return true;
        }

        public override string ToString() {
            if (Index == null) {
                return "";
            } else {
                return Index.ToString();
            }
        }

        public virtual int CompareTo(PartIndex o) {
            if (this == o || this.Index == o.Index) {
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
}