using System;

namespace AQDEF.Sharp.Models {
    public class ValueIndex : IComparable<ValueIndex> {
        private ValueIndex(PartIndex partIndex, CharacteristicIndex characteristicIndex, int? valueIndex) {
            this.PartIndex = partIndex;
            this.CharacteristicIndex = characteristicIndex;
            this.Index = valueIndex;
        }
        public PartIndex PartIndex { get; }

        public CharacteristicIndex CharacteristicIndex { get; }

        public int? Index { get; }

        public virtual bool PlatiProVsechnyHodnotyDilu() {
            return Convert.ToInt32(0).Equals(CharacteristicIndex.Index);
        }
        public static ValueIndex Of(CharacteristicIndex characteristicIndex, int? valueIndex) {
            return new ValueIndex(characteristicIndex.PartIndex, characteristicIndex, valueIndex);
        }
        public static ValueIndex Of(PartIndex partIndex, CharacteristicIndex characteristicIndex, int? valueIndex) {
            return new ValueIndex(partIndex, characteristicIndex, valueIndex);
        }
        public static ValueIndex Of(int? partIndex, int? characteristicIndex, int? valueIndex) {
            return new ValueIndex(PartIndex.Of(partIndex), CharacteristicIndex.of(partIndex, characteristicIndex), valueIndex);
        }
        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((CharacteristicIndex == null) ? 0 : CharacteristicIndex.GetHashCode());
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
            if (!(obj is ValueIndex)) {
                return false;
            }
            ValueIndex other = (ValueIndex)obj;
            if (CharacteristicIndex == null) {
                if (other.CharacteristicIndex != null) {
                    return false;
                }
            } else if (!CharacteristicIndex.Equals(other.CharacteristicIndex)) {
                return false;
            }
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

        public virtual int CompareTo(ValueIndex o) {
            if (this == o) {
                return 0;
            }
            int compareResultPart = this.PartIndex.CompareTo(o.PartIndex);
            if (compareResultPart != 0) {
                return compareResultPart;
            } else {
                int compareResultCharacteristic = this.CharacteristicIndex.CompareTo(o.CharacteristicIndex);

                if (compareResultCharacteristic != 0) {
                    return compareResultCharacteristic;
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
        }

        public override string ToString() {
            string result = "";
            if (CharacteristicIndex != null) {
                result += CharacteristicIndex.ToString();
            }
            result += "/";
            if (Index != null) {
                result += Index;
            }
            return result;
        }

    }
}