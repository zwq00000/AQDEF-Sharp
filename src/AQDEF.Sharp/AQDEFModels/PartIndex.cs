using System;

namespace AQDEF.Sharp.Models {
    /// <summary>
    /// @author Vlastimil Dolejs
    /// 
    /// </summary>
    public class PartIndex : IComparable<PartIndex> {
        private readonly int? Index_Renamed;

        private PartIndex(int? index) {
            this.Index_Renamed = index;
        }

        public virtual int? Index {
            get {
                return Index_Renamed;
            }
        }

        public static PartIndex of(int? index) {
            return new PartIndex(index);
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((Index_Renamed == null) ? 0 : Index_Renamed.GetHashCode());
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
            if (Index_Renamed == null) {
                if (other.Index_Renamed != null) {
                    return false;
                }
            } else if (!Index_Renamed.Equals(other.Index_Renamed)) {
                return false;
            }
            return true;
        }

        public override string ToString() {
            if (Index_Renamed == null) {
                return "";
            } else {
                return Index_Renamed.ToString();
            }
        }

        public virtual int CompareTo(PartIndex o) {
            if (this == o || this.Index_Renamed == o.Index_Renamed) {
                return 0;
            }
            if (this.Index_Renamed == null) {
                return -1;
            }
            if (o.Index_Renamed == null) {
                return 1;
            }

            return this.Index_Renamed.Value.CompareTo(o.Index_Renamed);
        }
    }
}