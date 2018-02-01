using System;
using System.Collections.Generic;
using System.Text;

namespace AQDEF.Sharp.Converts {
    public class StringKKeyValueConverter : IKKeyValueConverter {
       
        #region Implementation of IKKeyValueConverter
        
        /// <inheritdoc />
        string IKKeyValueConverter.ToString(object value) {
            return value.ToString();
        }
        /// <inheritdoc />
        object IKKeyValueConverter.Convert(string value) {
            return value;
        }

        #endregion
    }
}