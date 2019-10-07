namespace AQDEF.Sharp.Models {
    /// <summary>
    /// Simple interface that enable access to object fields using K-keys.
    /// 
    /// @author Vlastimil Dolejs
    /// 
    /// </summary>
    public interface IHasKKeyValues {

        T GetValue<T>(KKey kKey);

    }
}