using System;

namespace AQDEF.Sharp.Converts {
    public class BooleanKKeyValueConverter : IKKeyValueConverter {
        
        public object Convert(string value) {

            if (string.IsNullOrEmpty(value)) {
                return  null;
            }
            int result = 0;
            int.TryParse(value, out result);
            return result == 1;
        }

        public string ToString(object value) {
            if (value == null) {
                return string.Empty;
            }
            var result = value as Boolean?;
            if (result.HasValue) {
                return result.Value ? "1" : "0";
            } else {
                return "0";
            }
            
        }
    }
}