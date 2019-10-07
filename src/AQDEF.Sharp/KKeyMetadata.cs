using System;
using System.Collections.Generic;
using System.Text;
using AQDEF.Sharp.Converts;
using AQDEF.Sharp.Properties;

namespace AQDEF.Sharp {
    /// <summary>
    /// Contains metadata of a {@link KKey}.
    /// <p> This class is immutable and therefore thread-safe. </p>
    /// @author Vlastimil Dolejs
    /// </summary>
    public class KKeyMetadata {
        private readonly string _tableName;
        private readonly KKeyFieldType _dataType;

        /**
         * Whether values of this column should be saved to DB.
         * There are some K-keys which should not be written to DB or has unknown column name.
         */
        private readonly bool _saveToDb;

        internal KKeyMetadata(string keyCode,
            [NotNull] KKeyFieldType dataType,
            int length = 0) {
            if (string.IsNullOrEmpty(keyCode)) {
                throw new ArgumentNullException(nameof(keyCode));
            }
            this.KeyCode = keyCode;
            this._dataType = dataType;
            if (length <= 0) {
                this.Length = GetDefaultLength(dataType);
            } else {
                this.Length = length;
            }
        }

        private KKeyMetadata([NotNull]string columnName,
           [NotNull] Type dataType,
           int length,
           [NotNull]IKKeyValueConverter converter,
           bool saveToDb) {
            if (string.IsNullOrEmpty(columnName)) {
                throw new ArgumentNullException(nameof(columnName));
            }

            this.ColumnName = columnName;
            //this._dataType = dataType;
            this.Length = length;
            this._saveToDb = saveToDb;
        }


        internal KKeyMetadata(string keyCode,
            [NotNull] KKeyFieldType dataType,
            int length,
            string displayName
            ) : this(keyCode, dataType, length) {
            this.DisplayName = displayName;
        }

        /// <summary>
        /// 根据数据类型获取默认长度
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        private int GetDefaultLength(KKeyFieldType fieldType) {
            switch (fieldType) {
                case KKeyFieldType.A:
                    return 255;
                case KKeyFieldType.D:
                    return 22;
                case KKeyFieldType.F:
                    return 22;
                case KKeyFieldType.I10:
                    return 10;
                case KKeyFieldType.I5:
                    return 5;
                case KKeyFieldType.I3:
                    return 3;
                case KKeyFieldType.S:
                    return 0;
                default:
                    return 0;
            }
        }

        /*
        public static KKeyMetadata of<T>(String columnName, bool saveToDb, int length = 0) {
            return of(columnName,typeof(T), length, saveToDb);
        }
        
        public static KKeyMetadata of(String columnName, Type dataType, int length = 0) {
            return of(columnName, dataType, length, true);
        }
        */


        public static KKeyMetadata of(String columnName, Type dataType, int length = 0, bool saveToDb = true) {

            IKKeyValueConverter converter;
            if (typeof(string) == dataType || typeof(Guid) == dataType) {

                converter = new StringKKeyValueConverter();

            } else if (typeof(int) == dataType) {

                converter = new IntegerKKeyValueConverter();

            } else if (typeof(decimal) == dataType) {

                converter = new BigDecimalKKeyValueConverter();

            } else if (typeof(DateTime) == dataType) {

                converter = new DateKKeyValueConverter();

            } else {

                throw new ArgumentException("There is no converter defined for data type: " + dataType.Name);

            }

            return new KKeyMetadata(columnName, dataType, length, converter, saveToDb);
        }

        public static KKeyMetadata of<T>(String columnName, Type dataType, IKKeyValueConverter converter, bool saveToDb) where T : IConvertible {
            return new KKeyMetadata(columnName, dataType, 0, converter, saveToDb);
        }

        public static KKeyMetadata of<T>(String columnName, Type dataType, int length, IKKeyValueConverter converter) where T : IConvertible {
            return new KKeyMetadata(columnName, dataType, length, converter, true);
        }

        public string KeyCode { get; private set; }

        /// <summary>
        /// Returns the maximum length of the content of this K-key as defined in AQDEF format documentation.
        /// </summary>
        /// <value></value>
        public int Length { get; private set; }

        /// <summary>
        /// Returns name of the DB column in the Q-DAS database where this K-key is stored.
        /// </summary>
        /// <value></value>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Returns datatype of this K-key.
        /// </summary>
        /// <value></value>
        public KKeyFieldType DataType {
            get { return _dataType; }
        }

        /// <summary>
        /// Returns converter that can be used to convert the value of this K-key from and to the textual representation of AQDEF format.
        /// </summary>
        /// <value></value>
        public IKKeyValueConverter Converter {
            get { return ConvertFactory.GetConverter(this.DataType); }
        }

        /// <summary>
        /// Whether this K-key is stored in Q-DAS database.
        /// </summary>
        /// <returns></returns>
        public bool isSaveToDb => _saveToDb;

        public string DisplayName { get; }

        public override String ToString() {
            //return ToStringBuilder.reflectionToString(this);
            return $"{ColumnName} {DataType}";
        }

        public override bool Equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is KKeyMetadata)) {
                return false;
            }
            KKeyMetadata other = (KKeyMetadata)obj;
            if (ColumnName == null) {
                if (other.ColumnName != null) {
                    return false;
                }
            } else if (!ColumnName.Equals(other.ColumnName)) {
                return false;
            }
            if (_dataType != other._dataType) {
                return false;
            }
            if (Length != other.Length) {
                return false;
            }
            if (_saveToDb != other._saveToDb) {
                return false;
            }
            return true;
        }
    }
}
