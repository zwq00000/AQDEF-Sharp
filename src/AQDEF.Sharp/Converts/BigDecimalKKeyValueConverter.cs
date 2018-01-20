using System;

namespace AQDEF.Sharp.Converts {
    public class BigDecimalKKeyValueConverter : IKKeyValueConverter<decimal?> {


        public Decimal? convert(String value) {
            if (string.IsNullOrEmpty(value)) {
                return null;
            }

            decimal val;
            decimal.TryParse(value, out val);
            return val;
        }


        public String toString(decimal? value) {
            if (value.HasValue) {
                return value.ToString();
            }
            return null;
        }

    }
}