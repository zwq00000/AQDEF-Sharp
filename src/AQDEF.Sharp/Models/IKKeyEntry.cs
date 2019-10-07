namespace AQDEF.Sharp.Models {
    /// <summary>
    /// 表示 DFQ 文件中的一条记录
    /// 通常形式为 "Kxxxx/1 values"
    /// </summary>
    public interface IKKeyEntry {

        /// <summary>
        /// Key <see cref="KKey"/>
        /// </summary>
        KKey Key { get; }

        /// <summary>
        /// 索引
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// 设置数值<see cref="KKey.Converter"/>
        /// </summary>
        /// <param name="value"></param>
        void SetValue(object value);

        /// <summary>
        /// 转换后的值
        /// </summary>
        object Value { get; }
    }
}