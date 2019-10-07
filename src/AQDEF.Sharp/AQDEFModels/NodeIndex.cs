using System;

namespace AQDEF.Sharp.AQDEFModels {
    public class NodeIndex : IComparable<NodeIndex> {
        private NodeIndex(int? index) {
            Index = index;
        }

        public int? Index { get; }

        public static NodeIndex Of(int? index) {
            return new NodeIndex(index);
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + Index.GetHashCode();
            return result;
        }

        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is NodeIndex)) {
                return false;
            }
            NodeIndex other = (NodeIndex)obj;
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

        public virtual int CompareTo(NodeIndex o) {
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