namespace AQDEF.Models {
    /// <summary>
    /// KKey ����ģ��������
    /// </summary>
    public interface IEntiesOwner {

        /// <summary>
        /// ������
        /// </summary>
        BaseEnties SharedEnties { get; }
    }
}