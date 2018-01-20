using System;
using System.Collections.Generic;
using System.Text;

namespace AQDEF.Sharp.Converts {
    public class StringKKeyValueConverter : IKKeyValueConverter<String> {
        public String convert(String value) {
            return value;
        }

        /// <inheritdoc />
        string IKKeyValueConverter.toString(object value) {
            throw new NotImplementedException();
        }

        public String toString(String value) {
            return value;
        }

        #region Implementation of IKKeyValueConverter

        /// <inheritdoc />
        object IKKeyValueConverter.convert(string value) {
            return convert(value);
        }

        #endregion
    }
}