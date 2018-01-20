using System;
using System.Collections.Generic;
using System.Text;
using AQDEF.Sharp.Converts;

namespace AQDEF.Sharp {
    /// <summary>
    /// Contains metadata of a {@link KKey}.
    /// <p> This class is immutable and therefore thread-safe. </p>
    /// @author Vlastimil Dolejs
    /// </summary>
    public class KKeyMetadata {

        private readonly string columnName;
        private readonly Type dataType;

        ///<Summary>
        /// Length of data (for String and Number data types)
        ///</Summary>
        private readonly int length;

        /// <summary>
        /// 
        /// </summary>
        private IKKeyValueConverter converter;

        /**
         * Whether values of this column should be saved to DB.
         * There are some K-keys which should not be written to DB or has unknown column name.
         */
        private readonly bool saveToDb;

        private KKeyMetadata([NotNull]string columnName,
            [NotNull] Type dataType,
            int length,
            [NotNull]IKKeyValueConverter converter,
            bool saveToDb) {
            if (string.IsNullOrEmpty(columnName)) {
                throw new ArgumentNullException(nameof(columnName));
            }

            this.columnName = columnName;
            this.dataType = dataType;
            this.length = length;
            this.converter = converter;
            this.saveToDb = saveToDb;
        }


        public static KKeyMetadata of<T>(String columnName, bool saveToDb, int length = 0) {
            return of(columnName,typeof(T), length, saveToDb);
        }

        public static KKeyMetadata of<T>(String columnName, int length = 0) {
            return of(columnName, typeof(T), length, true);
        }

        public static KKeyMetadata of(String columnName, Type dataType, int length, bool saveToDb) {

            IKKeyValueConverter converter;
            if (typeof(string) == dataType || typeof(Guid) == dataType) {

                converter = new StringKKeyValueConverter();

            } else if (typeof(int?) == dataType) {

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

        public static KKeyMetadata of<T>(String columnName, Type dataType, IKKeyValueConverter<T> converter, bool saveToDb) where T : IConvertible {
            return new KKeyMetadata(columnName, dataType, 0, converter, saveToDb);
        }

        public static KKeyMetadata of<T>(String columnName, Type dataType, int length, IKKeyValueConverter<T> converter) where T : IConvertible {
            return new KKeyMetadata(columnName, dataType, length, converter, true);
        }

        /// <summary>
        /// Returns the maximum length of the content of this K-key as defined in AQDEF format documentation.
        /// </summary>
        /// <value></value>
        public int Length {
            get { return length; }
        }

        /// <summary>
        /// Returns name of the DB column in the Q-DAS database where this K-key is stored.
        /// </summary>
        /// <value></value>
        public string ColumnName {
            get { return columnName; }
        }

        /// <summary>
        /// Returns datatype of this K-key.
        /// </summary>
        /// <value></value>
        public Type DataType {
            get { return dataType; }
        }

        /// <summary>
        /// Returns converter that can be used to convert the value of this K-key from and to the textual representation of AQDEF format.
        /// </summary>
        /// <value></value>
        public IKKeyValueConverter Converter {
            get { return converter; }
        }

        /// <summary>
        /// Whether this K-key is stored in Q-DAS database.
        /// </summary>
        /// <returns></returns>
        public bool isSaveToDb() {
            return saveToDb;
        }


        public override String ToString() {
            //return ToStringBuilder.reflectionToString(this);
            return $"{ColumnName} {DataType.Name}";
        }

        public override int GetHashCode() {
            int prime = 31;
            int result = 1;
            result = prime * result + ((columnName == null) ? 0 : columnName.GetHashCode());
            result = prime * result + ((dataType == null) ? 0 : dataType.GetHashCode());
            result = prime * result + ((length == null) ? 0 : length);
            result = prime * result + (saveToDb ? 1231 : 1237);
            return result;
        }

        public bool Equals(Object obj) {
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
            if (columnName == null) {
                if (other.columnName != null) {
                    return false;
                }
            } else if (!columnName.Equals(other.columnName)) {
                return false;
            }
            if (dataType == null) {
                if (other.dataType != null) {
                    return false;
                }
            } else if (dataType != other.dataType) {
                return false;
            }
            if (length == null) {
                if (other.length != null) {
                    return false;
                }
            } else if (length != other.length) {
                return false;
            }
            if (saveToDb != other.saveToDb) {
                return false;
            }
            return true;
        }
    }

    public class CacheLoader<String, KKey> {

    }

    internal class LoadingCache<String, KKey> {

        public KKey get(string key) {
            throw new NotImplementedException();
        }
    }

    internal static class CacheBuilder {
        public static void newBuilder() {

        }
    }


}
