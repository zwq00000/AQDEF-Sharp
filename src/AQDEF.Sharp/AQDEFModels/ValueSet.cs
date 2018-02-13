using System.Collections.Generic;
using AQDEF.Sharp.Models;

namespace AQDEF.Sharp.Models {
    /// <summary>
    /// Contains one "set" of values for all characteristics. <br>
    /// 
    /// @author Vlastimil Dolejs
    /// 
    /// </summary>
    public class ValueSet {
        internal readonly SortedDictionary<CharacteristicIndex, ValueEntries> ValuesOfCharacteristics;

        public ValueSet() : this(new SortedDictionary<CharacteristicIndex, ValueEntries>()) {
        }

        public ValueSet(SortedDictionary<CharacteristicIndex, ValueEntries> valuesOfCharacteristics) : base() {
            this.ValuesOfCharacteristics = valuesOfCharacteristics;
        }
        public virtual void addValueOfCharacteristic(CharacteristicIndex characteristicIndex, ValueEntries valueEntries) {
            ValuesOfCharacteristics[characteristicIndex] = valueEntries;
        }
        public virtual ICollection<CharacteristicIndex> CharacteristicIndexes {
            get {
                return ValuesOfCharacteristics.Keys;
            }
        }
        public virtual ValueEntries getValuesOfCharacteristic(CharacteristicIndex characteristicIndex) {
            return DictoryExtensions.GetValueOrNull<CharacteristicIndex, ValueEntries>(ValuesOfCharacteristics, characteristicIndex);
        }
        public virtual ICollection<ValueEntries> Values {
            get {
                return ValuesOfCharacteristics.Values;
            }
        }
    }
}