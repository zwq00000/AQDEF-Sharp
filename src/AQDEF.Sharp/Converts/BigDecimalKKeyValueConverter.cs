using System;

namespace AQDEF.Sharp.Converts {
    internal class BigDecimalKKeyValueConverter : IKKeyValueConverter {


        public object Convert(String value) {
            if (string.IsNullOrEmpty(value)) {
                return Decimal.Zero;
            }

            decimal val;
            decimal.TryParse(value, out val);
            return val;
        }

        public string ToString(object value) {
            if (value == null) {
                return string.Empty;
            }
            return value.ToString();
        }
    }
}