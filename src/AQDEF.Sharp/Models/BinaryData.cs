using System;

namespace AQDEF.Sharp.Models {
    public class BinaryData {
        private readonly string[] _values = new string[10];

        /// <summary>
        /// DataLine Item Length
        /// </summary>
        private int _length;

        public BinaryData(string[] values) {
            _length = values.Length;
            Array.Copy(values, _values, Math.Min(10, values.Length));
            
        }

        public string Value {
            get {
                return _values[0];
            }
        }
        public string Attribute {
            get {
                return _values[1];
            }
        }
        public string Datetime {
            get {
                return _values[2];
            }
        }
        public string Events {
            get {
                return _values[3];
            }
        }
        public string BatchNnumber {
            get {
                return _values[4];
            }
        }
        public string NestNumber {
            get {
                return _values[5];
            }
        }
        public string OperatorNumber {
            get {
                return _values[6];
            }
        }
        public string MachineNumber {
            get {
                return _values[7];
            }
        }
        public string ProcessParameter {
            get {
                return _values[8];
            }
        }

        public string GageNumber {
            get { return _values[9]; }
        }

        #region Overrides of Object

        /// <summary>���ر�ʾ��ǰ <see cref="T:System.Object" /> �� <see cref="T:System.String" />��</summary>
        /// <returns>
        /// <see cref="T:System.String" />����ʾ��ǰ�� <see cref="T:System.Object" />��</returns>
        public override string ToString() {
            return
                $"Value:{Value} DateTime:{Datetime} Attribute:{Attribute} Events:{Events}  Batch:{BatchNnumber} NestNumber:{NestNumber} Operator:{OperatorNumber} " +
                $"Machine:{MachineNumber} Process:{ProcessParameter} Gage:{GageNumber}";
        }

        #endregion
    }
}