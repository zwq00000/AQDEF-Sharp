namespace AQDEF.Sharp.AQDEFModels {
    /// <summary>
    /// Simple interface that enable access to object fields using K-keys.
    /// 
    /// @author Vlastimil Dolejs
    /// 
    /// </summary>
    public interface IHasKKeyValues {

        T getValue<T>(KKey kKey);

    }
}