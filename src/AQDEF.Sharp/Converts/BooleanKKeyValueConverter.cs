using System;

namespace AQDEF.Sharp.Converts {
    public class BooleanKKeyValueConverter : IKKeyValueConverter<bool?> {
        private static IntegerKKeyValueConverter integerConverter = new IntegerKKeyValueConverter();


        public bool? convert(String value) {
            var integerValue = integerConverter.convert(value);

            if (integerValue == null) {
                return null;
            }
            if (integerValue == 1) {
                return true;
            }
            if (integerValue == 0) {
                return false;
            }
            throw new KKeyValueConversionException(value, typeof(bool), null);
        }

        public String toString(bool? value) {
            if (value == null) {
                return null;
            }
            return value.Value ? "1" : "0";
        }
    }
}