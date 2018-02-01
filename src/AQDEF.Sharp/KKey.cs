using System;
using System.Collections.Generic;
using AQDEF.Sharp.Properties;

namespace AQDEF.Sharp {
    /// <Summary>
    ///     K-key (also referred to as 'Key field' / 'K field' in the documentation of AQDEF format)
    ///     <p>
    ///         Represents single key in AQDEF format (e.g. K1001) and can be used to create AQDEF data structure (K-key :
    ///         value pairs).
    ///     </p>
    ///     <p>
    ///         You can obtain {@link KKey} instance by calling {@link KKey#of(String)}.
    ///         <br/>
    ///             K-key instances are thread safe, immutable and cached. If you call {@link KKey#of(String)} for the same
    ///             K-key multiple times,
    ///             you will probably get the same instances of {@link KKey} (this behavior is not guaranteed).
    ///     </p>
    ///     <p>
    ///         K-key also provides some {@link KKeyMetadata metadata} like datatype of the K-key. These can be retrieved like
    ///         this:
    ///         <pre>
    ///             KKey kKey = KKey.of("K1001");
    ///             KKeyMetadata metadata = kKey.getMetadata();
    ///         </pre>
    ///         Or you can directly read metadata properties using delegate methods {@link #getDataType()}, {@link
    ///         #getConverter()} etc.
    ///     </p>
    ///     @author Vlastimil Dolejs
    /// </Summary>
    public class KKey : IComparable<KKey> {
        [Flags]
        public enum KKeyLevel{
            PART,
            CHARACTERISTIC,
            VALUE,
            CUSTOM_PART,
            CUSTOM_CHARACTERISTIC,
            CUSTOM_VALUE,
            GROUP,
            HIERARCHY,
            SIMPLE_HIERARCHY,
            CATALOG,
            UNKNOWN
        }

        #region Attributes

        //*******************************************

        private static readonly Logger LOG = new Logger(typeof(KKey)); //LoggerFactory.getLogger(KKey.class);

        #endregion

        private static readonly IDictionary<string, KKey> Cache = new Dictionary<string, KKey>();


        private KKeyLevel? _level;
        private KKeyMetadata _metadata;

        //*******************************************
        // Constructors
        //*******************************************

        private KKey(string key) {
            Key = key;
        }

        internal KKey(string key, KKeyMetadata metadata) {
            this.Key = key;
            this._metadata = metadata;
        }

        #region Properties
        
        public string Key { get; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName {
            get { return Resources.ResourceManager.GetString(this.Key); }
        }

        /// <summary>
        ///     See {@link KKeyMetadata#getConverter()}
        /// </summary>
        /// <returns></returns>
        public IKKeyValueConverter Converter {
            get {
                if (_metadata == null) _metadata = FindMetadata();

                if (_metadata?.Converter == null) {
                    LOG.error("Can't find converter for k-key: " + Key);
                    return null;
                }
                return _metadata.Converter;
            }
        }

        /// <summary>
        /// See <see cref="KKeyMetadata.ColumnName"/>
        /// </summary>
        public string DbColumnName {
            get {
                if (_metadata == null) _metadata = FindMetadata();

                if (_metadata?.ColumnName == null) {
                    LOG.error("Can't find DB column name for k-key: " + Key);
                    return null;
                }
                return _metadata.ColumnName;
            }
        }

        /// <summary>
        /// See <see cref="KKeyMetadata.DataType"/>
        /// </summary>
        public KKeyFieldType  DataType {
            get {
                if (_metadata == null) _metadata = FindMetadata();

                if (_metadata == null || _metadata.DataType == null) {
                    LOG.error("Can't find data type of k-key: " + Key);
                    return KKeyFieldType.Unknown;
                }
                return _metadata.DataType;
            }
        }

        /// <summary>
        /// Gets <see cref="KKeyMetadata">metadata} of this K-key</see>
        /// </summary>
        public KKeyMetadata Metadata {
            get {
                if (_metadata == null) {
                    _metadata = FindMetadata();

                    if (_metadata == null) {
                        LOG.error("Can't find metadata for k-key: " + Key);
                        return null;
                    }
                }

                return _metadata;
            }
        }

        /// <summary>
        /// Returns <see cref="KKeyLevel"/> of the AQDEF structure this K-key belongs to.
        /// </summary>
        public KKeyLevel Level {
            get {
                if (_level == null) _level = DetermineLevel();

                return _level.Value;
            }
        }

        /// <summary>
        ///  return whether this key represents information for part (dil / teil)
        /// </summary>
        public bool IsPartLevel => Level == KKeyLevel.PART;


        /// <summary>
        /// return whether this key represents information about logical group
        /// </summary>
        public bool IsGroupLevel => Level == KKeyLevel.GROUP;

        /// <summary>
        /// return whether this key represents information about hierarchy
        /// </summary>
        public bool IsHierarchyLevel => Level == KKeyLevel.HIERARCHY;

        /// <summary>
        /// return whether this key represents information about simple hierarchy
        /// </summary>
        public bool IsSimpleHierarchyLevel => Level == KKeyLevel.SIMPLE_HIERARCHY;

        /// <summary>
        /// return whether this key represents information for characterstic (znak / merkmal)
        /// </summary>
        /// <returns></returns>
        public bool IsCharacteristicLevel => Level == KKeyLevel.CHARACTERISTIC;

        /// <summary>
        /// return whether this key represents information for value (hodnota / wertevar)
        /// </summary>
        /// <returns></returns>
        public bool IsValueLevel => Level == KKeyLevel.VALUE;

        /// <summary>
        /// return whether this key represents our custom key
        /// </summary>
        public bool IsCustom {
            get {
                var level = Level;

                return level == KKeyLevel.CUSTOM_VALUE || level == KKeyLevel.CUSTOM_CHARACTERISTIC ||
                       level == KKeyLevel.CUSTOM_PART;
            }
        }

        /// <summary>
        /// return whether this k-key should be written to DFQ file
        /// </summary>
        public bool ShouldBeWrittenToDfq {
            get {
                if (IsCustom) return false;

                return true;
            }
        }

        #endregion

        public int CompareTo(KKey o) {
            if (Key == null && o.Key == null) return 0;
            if (Key == null && o.Key != null) return 1;
            if (Key != null && o.Key == null) return -1;

            var thisKey = KeyForCompare(Key);
            var otherKey = KeyForCompare(o.Key);
            return thisKey.CompareTo(otherKey);
        }

        /// <summary>
        ///     Gets the instance of {@link KKey} for the given {@code key}.
        ///     Returned instance may not be a new instance, but reused instance from cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static KKey Of(string key) {
            KKey instance;
            if (!Cache.TryGetValue(key, out instance)) {
                instance = new KKey(key);
                Cache.Add(key,instance);
            }
            return instance;
        }

        private KKeyMetadata FindMetadata() {
            if (Level == KKeyLevel.CATALOG) return CatalogField.getMetadataFor(this);
            return KKeyRepository.getInstance().GetMetadataFor(this);
        }

        private KKeyLevel DetermineLevel() {
            if (Key == null) {
                LOG.error("K-key with missing key.");
                return KKeyLevel.UNKNOWN;
            }

            if (string.Equals(Key, "K2030", StringComparison.CurrentCultureIgnoreCase) ||
                Key.Equals("K2031", StringComparison.CurrentCultureIgnoreCase)) return KKeyLevel.SIMPLE_HIERARCHY;
            if (Key.StartsWith("K1")) return KKeyLevel.PART;
            if (Key.StartsWith("K2") // characteristic properties
                || Key.StartsWith("K8")) return KKeyLevel.CHARACTERISTIC;
            if (Key.StartsWith("K0")) return KKeyLevel.VALUE;
            if (Key.StartsWith("K4")) return KKeyLevel.CATALOG;
            if (Key.StartsWith("K50")) return KKeyLevel.GROUP;
            if (Key.StartsWith("K51")) return KKeyLevel.HIERARCHY;
            if (Key.StartsWith("KX0")) return KKeyLevel.CUSTOM_VALUE;
            if (Key.StartsWith("KX2")) return KKeyLevel.CUSTOM_CHARACTERISTIC;
            if (Key.StartsWith("KX1")) return KKeyLevel.CUSTOM_PART;
            LOG.error("Unknown level of k-key " + Key);
            return KKeyLevel.UNKNOWN;
        }


        public override int GetHashCode() {
            var prime = 31;
            var result = 1;
            result = prime * result + (Key == null ? 0 : Key.GetHashCode());
            return result;
        }

        public override bool Equals(object obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            if (!(obj is KKey)) return false;
            var other = (KKey) obj;
            if (Key == null) {
                if (other.Key != null) return false;
            } else if (!Key.Equals(other.Key)) {
                return false;
            }
            return true;
        }

        public override string ToString() {
            return Key;
        }

        private string KeyForCompare(string key) {
            // K0020 and K0021 has to be written of the same position as K0001 - this will change the order for these 2 keys
            if (key.Equals("K0020")) return "K0001.20";

            if (key.Equals("K0021")) return "K0001.21";

            return key;
        }
    }
}