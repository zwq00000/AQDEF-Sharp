using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AQDEF.Sharp
{
    public static class AqdefConstants {
        /// <summary>
        /// Separates lines of data file
        /// </summary>
        public const string LineSeparator = "\r\n";
        /// <summary>
        /// Separates value from k-key on single line
        /// </summary>
        public const string ValuesSeparator = " ";

        /// <summary>
        /// Separates fields of single characteristic in lines with measured values (notation without the use of K-Keys)<br>
        /// The sequence of fields is:<br>
        /// 1 Value<br>
        /// 2 Attribute<br>
        /// 3 Date/Time<br>
        /// 4 Events<br>
        /// 5 Batch number<br>
        /// 6 Nest number<br>
        /// 7 Operator number<br>
        /// 8 Machine number<br>
        /// 9 Process parameter<br>
        /// 10 Gage number<br>
        /// </summary>
        public const char MeasuredValuesDataSeparator = (char) 20;

        /// <summary>
        /// Separates characteristic portions in lines with measured values (notation without the use of K-Keys)
        /// </summary>
        public const char MeasuredValuesCharacteristicSeparator = ((char) 15);
    }
}
