using System;

namespace AQDEF.Sharp.Models {
    public class ValueIndex : IComparable<ValueIndex> {
        private readonly PartIndex PartIndex_Renamed;
        private readonly CharacteristicIndex CharacteristicIndex_Renamed;
        private readonly int? ValueIndex_Renamed;

        private ValueIndex(PartIndex partIndex, CharacteristicIndex characteristicIndex, int? valueIndex) {
            this.PartIndex_Renamed = partIndex;
            this.CharacteristicIndex_Renamed = characteristicIndex;
            this.ValueIndex_Renamed = valueIndex;
        }
        public virtual PartIndex PartIndex {
            get {
                return PartIndex_Renamed;
            }
        }
        public virtual CharacteristicIndex CharacteristicIndex {
            get {
                return CharacteristicIndex_Renamed;
            }
        }
        public virtual int? getValueIndex() {
            return ValueIndex_Renamed;
        }
        public virtual bool platiProVsechnyHodnotyDilu() {
            return Convert.ToInt32(0).Equals(CharacteristicIndex_Renamed.getCharacteristicIndex());
        }
        public static ValueIndex of(CharacteristicIndex characteristicIndex, int? valueIndex) {
            return new ValueIndex(characteristicIndex.PartIndex, characteristicIndex, valueIndex);
        }
        public static ValueIndex of(PartIndex partIndex, CharacteristicIndex characteristicIndex, int? valueIndex) {
            return new ValueIndex(partIndex, characteristicIndex, valueIndex);
        }
        public static ValueIndex of(int? partIndex, int? characteristicIndex, int? valueIndex) {
            return new ValueIndex(PartIndex.of(partIndex), CharacteristicIndex.of(partIndex, characteristicIndex), valueIndex);
        }
        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((CharacteristicIndex_Renamed == null) ? 0 : CharacteristicIndex_Renamed.GetHashCode());
            result = prime * result + ((PartIndex_Renamed == null) ? 0 : PartIndex_Renamed.GetHashCode());
            result = prime * result + ((ValueIndex_Renamed == null) ? 0 : ValueIndex_Renamed.GetHashCode());
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
            if (CharacteristicIndex_Renamed == null) {
                if (other.CharacteristicIndex_Renamed != null) {
                    return false;
                }
            } else if (!CharacteristicIndex_Renamed.Equals(other.CharacteristicIndex_Renamed)) {
                return false;
            }
            if (PartIndex_Renamed == null) {
                if (other.PartIndex_Renamed != null) {
                    return false;
                }
            } else if (!PartIndex_Renamed.Equals(other.PartIndex_Renamed)) {
                return false;
            }
            if (ValueIndex_Renamed == null) {
                if (other.ValueIndex_Renamed != null) {
                    return false;
                }
            } else if (!ValueIndex_Renamed.Equals(other.ValueIndex_Renamed)) {
                return false;
            }
            return true;
        }

        public virtual int CompareTo(ValueIndex o) {
            if (this == o) {
                return 0;
            }
            int compareResultPart = this.PartIndex_Renamed.CompareTo(o.PartIndex_Renamed);
            if (compareResultPart != 0) {
                return compareResultPart;
            } else {
                int compareResultCharacteristic = this.CharacteristicIndex_Renamed.CompareTo(o.CharacteristicIndex_Renamed);

                if (compareResultCharacteristic != 0) {
                    return compareResultCharacteristic;
                } else {
                    if (this.ValueIndex_Renamed == o.ValueIndex_Renamed) {
                        return 0;
                    }
                    if (this.ValueIndex_Renamed == null) {
                        return -1;
                    }
                    if (o.ValueIndex_Renamed == null) {
                        return 1;
                    }

                    return this.ValueIndex_Renamed.Value.CompareTo(o.ValueIndex_Renamed);
                }
            }
        }

        public override string ToString() {
            string result = "";
            if (CharacteristicIndex_Renamed != null) {
                result += CharacteristicIndex_Renamed.ToString();
            }
            result += "/";
            if (ValueIndex_Renamed != null) {
                result += ValueIndex_Renamed;
            }
            return result;
        }

    }
}