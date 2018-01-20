using System;

namespace AQDEF.Sharp {

 ///<Summary>
 /// K-key (also referred to as 'Key field' / 'K field' in the documentation of AQDEF format)
 /// <p>
 /// Represents single key in AQDEF format (e.g. K1001) and can be used to create AQDEF data structure (K-key : value pairs).
 /// </p>
 /// <p>
 /// You can obtain {@link KKey} instance by calling {@link KKey#of(String)}. <br>
 /// K-key instances are thread safe, immutable and cached. If you call {@link KKey#of(String)} for the same K-key multiple times,
 /// you will probably get the same instances of {@link KKey} (this behavior is not guaranteed).
 /// </p>
 /// <p>
 /// K-key also provides some {@link KKeyMetadata metadata} like datatype of the K-key. These can be retrieved like this:
 /// <pre>
 ///  KKey kKey = KKey.of("K1001");
 ///  KKeyMetadata metadata = kKey.getMetadata();
 /// </pre>
 /// Or you can directly read metadata properties using delegate methods {@link #getDataType()}, {@link #getConverter()} etc.
 /// </p>
 ///
 ///
 /// @author Vlastimil Dolejs
 ///
 ///</Summary>
 
    
    public class KKey:IComparable<KKey> {
        #region Attributes
        //*******************************************

        private static Logger LOG = new Logger(); //LoggerFactory.getLogger(KKey.class);

        #endregion

        public enum Level {
            PART, CHARACTERISTIC, VALUE,
            CUSTOM_PART, CUSTOM_CHARACTERISTIC, CUSTOM_VALUE,
            GROUP, HIERARCHY, SIMPLE_HIERARCHY, CATALOG, UNKNOWN
        }

        private static  LoadingCache<String, KKey> CACHE = new LoadingCache<string, KKey>();
    

        private String key;

        private Level level;
        private KKeyMetadata metadata;

        //*******************************************
        // Constructors
        //*******************************************

        private KKey(String key) {
            this.key = key;
        }

        /// <summary>
        /// Gets the instance of {@link KKey} for the given {@code key}.
        /// Returned instance may not be a new instance, but reused instance from cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static KKey of(String key) {
            try {
                return CACHE.get(key);
            } catch (Exception e) {
                throw ;
            }
        }

//*******************************************
// Methods
//*******************************************

        public String getKey() {
            return key;
        }

        /// <summary>
        /// See {@link KKeyMetadata#getConverter()}
        /// </summary>
        /// <returns></returns>
        public IKKeyValueConverter getConverter() {
            if (metadata == null) {
                metadata = findMetadata();
            }

            if (metadata?.Converter == null) {
                LOG.error("Can't find converter for k-key: " + key);
                return null;
            } else {
                return metadata.Converter;
            }
        }

/**
 * See {@link KKeyMetadata#getColumnName()}
 *
 * @return
 */
        public String getDbColumnName() {
            if (metadata == null) {
                metadata = findMetadata();
            }

            if (metadata?.ColumnName == null) {
                LOG.error("Can't find DB column name for k-key: " + key);
                return null;
            } else {
                return metadata.ColumnName;
            }
        }

/**
 * See {@link KKeyMetadata#getDataType()}
 *
 * @return
 */
        public Class<?> getDataType() {
            if (metadata == null) {
                metadata = findMetadata();
            }

            if (metadata == null || metadata.DataType == null) {
                LOG.error("Can't find data type of k-key: " + key);
                return null;
            } else {
                return metadata.DataType;
            }
        }

/**
 * Gets {@link KKeyMetadata metadata} of this K-key
 *
 * @return
 */
        public KKeyMetadata getMetadata() {
            if (metadata == null) {
                metadata = findMetadata();

                if (metadata == null) {
                    LOG.error("Can't find metadata for k-key: " + key);
                    return null;
                }
            }

            return metadata;
        }

        private KKeyMetadata findMetadata() {
            if (getLevel() == Level.CATALOG) {
                return CatalogField.getMetadataFor(this);
            } else {
                return KKeyRepository.getInstance().getMetadataFor(this);
            }
        }

/**
 * Returns {@link Level} of the AQDEF structure this K-key belongs to.
 *
 * @return
 */
        public Level getLevel() {
            if (level == null) {
                level = determineLevel();
            }

            return level;
        }

        private Level determineLevel() {
            if (key == null) {
                LOG.error("K-key with missing key.");
                return Level.UNKNOWN;
            }

            if (string.Equals(key,"K2030",StringComparison.CurrentCultureIgnoreCase) || key.Equals("K2031",StringComparison.CurrentCultureIgnoreCase)) {

                return Level.SIMPLE_HIERARCHY;

            }
            if (key.StartsWith("K1")) {

                return Level.PART;

            }
            if (key.StartsWith("K2") // characteristic properties
                || key.StartsWith("K8")) { // control chart properties

                return Level.CHARACTERISTIC;

            }
            if (key.StartsWith("K0")) {

                return Level.VALUE;

            }
            if (key.StartsWith("K4")) {

                return Level.CATALOG;

            }
            if (key.StartsWith("K50")) {

                return Level.GROUP;

            }
            if (key.StartsWith("K51")) {

                return Level.HIERARCHY;

            }
            if (key.StartsWith("KX0")) {

                return Level.CUSTOM_VALUE;

            }
            if (key.StartsWith("KX2")) {

                return Level.CUSTOM_CHARACTERISTIC;

            }
            if (key.StartsWith("KX1")) {

                return Level.CUSTOM_PART;

            }
            LOG.error("Unknown level of k-key " + key);
            return Level.UNKNOWN;
        }
/**
 * @return whether this key represents information for part (dil / teil)
 */
        public bool isPartLevel() {
            return getLevel() == Level.PART;
        }

/**
 * @return whether this key represents information for characterstic (znak / merkmal)
 */
        public bool isCharacteristicLevel() {
            return getLevel() == Level.CHARACTERISTIC;
        }

/**
 * @return whether this key represents information for value (hodnota / wertevar)
 */
        public bool isValueLevel() {
            return getLevel() == Level.VALUE;
        }

/**
 * @return whether this key represents information about logical group
 */
        public bool isGroupLevel() {
            return getLevel() == Level.GROUP;
        }

/**
 * @return whether this key represents information about hierarchy
 */
        public bool isHierarchyLevel() {
            return getLevel() == Level.HIERARCHY;
        }

/**
 * @return whether this key represents information about simple hierarchy
 */
        public bool isSimpleHierarchyLevel() {
            return getLevel() == Level.SIMPLE_HIERARCHY;
        }

/**
 * @return whether this key represents our custom key
 */
        public bool isCustom() {
            Level level = getLevel();

            return level == Level.CUSTOM_VALUE || level == Level.CUSTOM_CHARACTERISTIC || level == Level.CUSTOM_PART;
        }

/**
 * @return whether this k-key should be written to DFQ file
 */
        public bool shouldBeWrittenToDfq() {
            if (isCustom()) {
                return false;
            }

            return true;
        }

    
        public override int GetHashCode() {
            int prime = 31;
            int result = 1;
            result = prime * result + ((key == null) ? 0 : key.GetHashCode());
            return result;
        }

        public override bool Equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (!(obj is KKey)) {
                return false;
            }
            KKey other = (KKey)obj;
            if (key == null) {
                if (other.key != null) {
                    return false;
                }
            } else if (!key.Equals(other.key)) {
                return false;
            }
            return true;
        }

        public override String ToString() {
            return key;
        }


        public int CompareTo(KKey o) {
            if (key == null && o.key == null) {
                return 0;
            }
            if (key == null && o.key != null) {
                return 1;
            }
            if (key != null && o.key == null) {
                return -1;
            }

            String thisKey = keyForCompare(key);
            String otherKey = keyForCompare(o.key);
            return thisKey.CompareTo(otherKey);
        }

        private String keyForCompare(string key) {
            // K0020 and K0021 has to be written of the same position as K0001 - this will change the order for these 2 keys
            if (key.Equals("K0020")) {
                return "K0001.20";
            }

            if (key.Equals("K0021")) {
                return "K0001.21";
            }

            return key;
        }

    }
}