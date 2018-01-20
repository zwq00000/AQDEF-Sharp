using System;

namespace AQDEF.Sharp.Converts {
    public class IntegerKKeyValueConverter : IKKeyValueConverter<int?> {

        public int? convert(String value) {
            if (String.IsNullOrEmpty(value)) {
                return null;
            }

            int val = 0;
            int.TryParse(value, out val);
            return val;
        }


        public String toString(int? value) {
            if (value == null) {
                return null;
            } else {
                return value.ToString();
            }
        }

    }
}