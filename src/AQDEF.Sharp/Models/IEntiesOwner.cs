namespace AQDEF.Sharp.Models {
    /// <summary>
    /// KKey 对象模型所有者
    /// </summary>
    public interface IEntiesOwner {

        /// <summary>
        /// 共享集合
        /// </summary>
        BaseEnties SharedEnties { get; }
    }
}