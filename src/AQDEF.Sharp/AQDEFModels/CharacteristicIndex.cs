using System;

namespace AQDEF.Sharp.Models {
    public class CharacteristicIndex : IComparable<CharacteristicIndex> {
        private readonly int? _characteristicIndex;

        private CharacteristicIndex(PartIndex partIndex, int? characteristicIndex) {
            this.PartIndex = partIndex;
            this._characteristicIndex = characteristicIndex;
        }

        public PartIndex PartIndex { get; }

        public int? Index {
            get { return _characteristicIndex; }
        }

        public bool PlatiProVsechnyZnakyDilu() {
            return Convert.ToInt32(0).Equals((object) _characteristicIndex);
        }

        public static CharacteristicIndex Of(PartIndex partIndex, int? characteristicIndex) {
            return new CharacteristicIndex(partIndex, characteristicIndex);
        }

        public static CharacteristicIndex Of(int? partIndex, int? characteristicIndex) {
            return Of(PartIndex.Of(partIndex), characteristicIndex);
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((PartIndex == null) ? 0 : PartIndex.GetHashCode());
            result = prime * result + ((_characteristicIndex == null) ? 0 : _characteristicIndex.GetHashCode());
            return result;
        }

        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is CharacteristicIndex)) {
                return false;
            }
            CharacteristicIndex other = (CharacteristicIndex)obj;
            if (PartIndex == null) {
                if (other.PartIndex != null) {
                    return false;
                }
            } else if (!PartIndex.Equals(other.PartIndex)) {
                return false;
            }
            if (_characteristicIndex == null) {
                if (other._characteristicIndex != null) {
                    return false;
                }
            } else if (!_characteristicIndex.Equals(other._characteristicIndex)) {
                return false;
            }
            return true;
        }

        public virtual int CompareTo(CharacteristicIndex o) {
            if (this == o) {
                return 0;
            }

            int compareResultPart = this.PartIndex.CompareTo(o.PartIndex);

            if (compareResultPart != 0) {
                return compareResultPart;
            } else {
                if (this._characteristicIndex == o._characteristicIndex) {
                    return 0;
                }
                if (this._characteristicIndex == null) {
                    return -1;
                }
                if (o._characteristicIndex == null) {
                    return 1;
                }

                return this._characteristicIndex.Value.CompareTo(o._characteristicIndex);
            }
        }

        public override string ToString() {
            string result = "";
            if (PartIndex != null) {
                result += PartIndex.ToString();
            }

            result += "/";

            if (_characteristicIndex != null) {
                result += _characteristicIndex;
            }

            return result;
        }

    }
}