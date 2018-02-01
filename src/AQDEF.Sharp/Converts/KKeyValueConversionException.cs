using System;

namespace AQDEF.Sharp.Converts {
    public class KKeyValueConversionException : Exception {


        public KKeyValueConversionException(String value, Type dataType, Exception cause) : base(
            $"Failed to convert value: {value} to data type: {dataType.Name}", cause) {

        }

        public KKeyValueConversionException(String message, Exception cause) : base(message, cause) {
        }
    }
}