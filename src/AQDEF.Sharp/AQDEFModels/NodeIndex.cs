using System;

namespace AQDEF.Sharp.Models {
    public class NodeIndex : IComparable<NodeIndex> {
        private readonly int _index;

        private NodeIndex(int index) {
            this._index = index;
        }

        public virtual int Index {
            get {
                return _index;
            }
        }

        public static NodeIndex of(int? index) {
            if (index.HasValue) {
                return new NodeIndex(index.Value);
            } else {
                return new NodeIndex(0);
            }
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((_index == null) ? 0 : _index.GetHashCode());
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
            if (_index == null) {
                if (other._index != null) {
                    return false;
                }
            } else if (!_index.Equals(other._index)) {
                return false;
            }
            return true;
        }

        public override string ToString() {
            if (_index == null) {
                return "";
            } else {
                return _index.ToString();
            }
        }

        public virtual int CompareTo(NodeIndex o) {
            if (this == o || this._index == o._index) {
                return 0;
            }
            if (this._index == null) {
                return -1;
            }
            if (o._index == null) {
                return 1;
            }

            return this._index.CompareTo(o._index);
        }
    }
}