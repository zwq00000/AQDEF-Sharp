using System;

namespace AQDEF.Sharp {
    /// <summary>
    /// Indicates that the AQDEF content has invalid structure, format or is malformed in another way.
    /// 
    /// @author Vlastimil Dolejs
    /// 
    /// </summary>
    public class AqdefValidityException : Exception {

        public AqdefValidityException() : base((string) "Invalid AQDEF structure.") {
        }

        public AqdefValidityException(string message, Exception cause) : base("Invalid AQDEF structure: " + message, cause) {
        }

        public AqdefValidityException(string message) : base("Invalid AQDEF structure: " + message) {
        }

        public AqdefValidityException(Exception cause) : base((string) "Invalid AQDEF structure.", cause) {
        }
    }
}