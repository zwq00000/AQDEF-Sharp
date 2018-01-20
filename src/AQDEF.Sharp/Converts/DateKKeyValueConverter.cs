using System;
using System.Globalization;

namespace AQDEF.Sharp.Converts {
    public class DateKKeyValueConverter : IKKeyValueConverter<DateTime?> {

        private const string OutputFormat = "dd.MM.yyyy/HH:mm:ss";

        private static readonly string[] InputFormats = new[] {"dd.MM.yyyy/HH:mm:ss","MM/dd/yyyy/HH:mm:ss","yyyy-MM-dd/HH:mm:ss","dd.MM.yyyy/HH:mm",
            "MM/dd/yyyy/HH:mm","yyyy-MM-dd/HH:mm","dd.MM.yyyy HH:mm:ss","MM/dd/yyyy HH:mm:ss","yyyy-MM-dd HH:mm:ss","dd.MM.yyyy HH:mm","MM/dd/yyyy HH:mm","yyyy-MM-dd HH:mm"};

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: @Override public Date convert(String value) throws KKeyValueConversionException
        public DateTime? convert(string value) {
            if (String.IsNullOrEmpty(value)) {
                return null;
            }
            DateTime result;
            DateTime.TryParseExact(value, InputFormats, new CultureInfo("en-US"), DateTimeStyles.None, out result);
            return (DateTime?)result;

            //throw new KKeyValueConversionException(value, typeof(DateTime), firstException);
        }

        /// <inheritdoc />
        public string toString(DateTime? value) {
            if (value == null) {
                return null;
            }
            return value.Value.ToString(OutputFormat);
        }

    }
}