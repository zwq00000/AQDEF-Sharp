using System;
using System.Globalization;

namespace AQDEF.Sharp.Converts {
    internal class DateKKeyValueConverter : IKKeyValueConverter {

        private const string OutputFormat = "dd.MM.yyyy/HH:mm:ss";

        private static readonly IFormatProvider FormatProvider = new CultureInfo("en-US");

        private static readonly string[] InputFormats = new[] {"dd.MM.yyyy/HH:mm:ss","d.M.yyyy/HH:mm:ss","MM/dd/yyyy/HH:mm:ss","yyyy-MM-dd/HH:mm:ss","dd.MM.yyyy/HH:mm",
            "MM/dd/yyyy/HH:mm","yyyy-MM-dd/HH:mm","dd.MM.yyyy HH:mm:ss","MM/dd/yyyy HH:mm:ss","yyyy-MM-dd HH:mm:ss","dd.MM.yyyy HH:mm","MM/dd/yyyy HH:mm","yyyy-MM-dd HH:mm"};

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: @Override public Date convert(String value) throws KKeyValueConversionException
        public object Convert(string value) {
            if (String.IsNullOrEmpty(value)) {
                return null;
            }
            DateTime result;
            if (DateTime.TryParseExact(value, InputFormats, FormatProvider, DateTimeStyles.None, out result)) {
                return result;
            }
            throw new KKeyValueConversionException(value, typeof(DateTime),null);
        }
        
        /// <inheritdoc />
        public string ToString(object value) {
            if (value == null) {
                return string.Empty;
            }
            var date = (DateTime) value;
            return date.ToString(OutputFormat);
        }
    }
}