using System;

namespace AQDEF.Sharp {
    [Flags]
    public enum KKeyLevel {
        /// <summary>
        /// 部件数据 (Part Data)
        /// </summary>
        Part,
        /// <summary>
        /// 特征数据 (Characteristic Data)
        /// </summary>
        Characteristic,
        /// <summary>
        /// 测量值
        /// </summary>
        VALUE,
        /// <summary>
        /// 自定义部件
        /// </summary>
        CUSTOM_PART,
        /// <summary>
        /// 自定义特征
        /// </summary>
        CUSTOM_CHARACTERISTIC,
        /// <summary>
        /// 自定义测量值
        /// </summary>
        CUSTOM_VALUE,
        /// <summary>
        /// 
        /// </summary>
        GROUP,
        HIERARCHY,
        SIMPLE_HIERARCHY,
        CATALOG,
        UNKNOWN
    }
}