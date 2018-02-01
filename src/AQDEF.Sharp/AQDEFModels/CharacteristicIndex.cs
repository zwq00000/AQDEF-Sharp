using System;

namespace AQDEF.Sharp.Models {
    public class CharacteristicIndex : IComparable<CharacteristicIndex> {
        private readonly PartIndex _partIndex;
        private readonly int? _characteristicIndex;

        private CharacteristicIndex(PartIndex partIndex, int? characteristicIndex) {
            this._partIndex = partIndex;
            this._characteristicIndex = characteristicIndex;
        }

        public virtual PartIndex PartIndex {
            get {
                return _partIndex;
            }
        }

        public virtual int? getCharacteristicIndex() {
            return _characteristicIndex;
        }

        public virtual bool platiProVsechnyZnakyDilu() {
            return Convert.ToInt32(0).Equals((object) _characteristicIndex);
        }

        public static CharacteristicIndex of(PartIndex partIndex, int? characteristicIndex) {
            return new CharacteristicIndex(partIndex, characteristicIndex);
        }

        public static CharacteristicIndex of(int? partIndex, int? characteristicIndex) {
            return of(PartIndex.of(partIndex), characteristicIndex);
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((_partIndex == null) ? 0 : _partIndex.GetHashCode());
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
            if (_partIndex == null) {
                if (other._partIndex != null) {
                    return false;
                }
            } else if (!_partIndex.Equals(other._partIndex)) {
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

            int compareResultPart = this._partIndex.CompareTo(o._partIndex);

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
            if (_partIndex != null) {
                result += _partIndex.ToString();
            }

            result += "/";

            if (_characteristicIndex != null) {
                result += _characteristicIndex;
            }

            return result;
        }

    }
}