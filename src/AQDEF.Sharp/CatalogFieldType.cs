namespace AQDEF.Sharp {
    public enum CatalogFieldType {
        /// <summary>
        /// Identifier of catalog (surrogate key)
        /// </summary>
        ID,
        
        /// <summary>
        /// Data fields contains actial data of the catalog record
        /// </summary>
        DATA,

        /// <summary>
        /// State fields tells if the catalog record is active or non-active (soft deleted)
        /// </summary>
        STATE
    }
}