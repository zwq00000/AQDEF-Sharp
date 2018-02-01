using System;

namespace AQDEF.Sharp.Converts {



    internal class ByteKKeyValueConverter : IKKeyValueConverter {
        #region Implementation of IKKeyValueConverter

        public object Convert(string value) {
            if (string.IsNullOrEmpty(value)) {
                return null;
            }
            byte result;
            byte.TryParse(value, out result);
            return result;
        }

        public string ToString(object value) {
            if (value == null) {
                return string.Empty;
            }
            return value.ToString();
        }

        #endregion
    }

    internal class ShortKKeyValueConverter : IKKeyValueConverter {
        #region Implementation of IKKeyValueConverter

        public object Convert(string value) {
            if (string.IsNullOrEmpty(value)) {
                return null;
            }
            short result;
            short.TryParse(value, out result);
            return result;
        }

        public string ToString(object value) {
            if (value == null) {
                return string.Empty;
            }
            return value.ToString();
        }

        #endregion
    }

    internal class IntegerKKeyValueConverter : IKKeyValueConverter {

        public object Convert(String value) {
            if (String.IsNullOrEmpty(value)) {
                return null;
            }

            int val = 0;
            int.TryParse(value, out val);
            return val;
        }

        public string ToString(object value) {
            if (value == null) {
                return string.Empty;
            } else {
                return value.ToString();
            }
        }
    }
}