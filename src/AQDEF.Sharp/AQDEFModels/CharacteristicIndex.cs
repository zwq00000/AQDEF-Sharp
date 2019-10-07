using System;

namespace AQDEF.Sharp.AQDEFModels {
    public class CharacteristicIndex : IComparable<CharacteristicIndex> {
        private CharacteristicIndex(PartIndex partIndex, int? characteristicIndex) {
            this.PartIndex = partIndex;
            this.Index = characteristicIndex;
        }

        public PartIndex PartIndex { get; }

        public int? Index { get; private set; }

        public bool platiProVsechnyZnakyDilu() {
            return Convert.ToInt32(0).Equals((object) Index);
        }

        public static CharacteristicIndex of(PartIndex partIndex, int? characteristicIndex) {
            return new CharacteristicIndex(partIndex, characteristicIndex);
        }

        public static CharacteristicIndex of(int? partIndex, int? characteristicIndex) {
            return of(PartIndex.Of(partIndex), characteristicIndex);
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
            if (Index == null) {
                if (other.Index != null) {
                    return false;
                }
            } else if (!Index.Equals(other.Index)) {
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