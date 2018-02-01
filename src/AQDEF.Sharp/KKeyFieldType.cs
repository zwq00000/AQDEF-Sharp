namespace AQDEF.Sharp {
    /// <summary>
    /// A alpha-numeric 
    ///  D date/time format 
    ///  F floating point number 
    ///  I3 integer (1 Byte) 
    ///  I5 integer (2 Byte) 
    /// I10 integer (4 Byte) 
    /// S special coding
    /// </summary>
    public enum KKeyFieldType{
        /// <summary>
        /// 字符串类型
        /// </summary>
        A,
        /// <summary>
        /// 日期
        /// </summary>
        D,
        /// <summary>
        /// 浮点数
        /// </summary>
        F,
        /// <summary>
        /// 整数 Byte
        /// </summary>
        I3,
        /// <summary>
        /// 整数 short
        /// </summary>
        I5,
        /// <summary>
        /// int32
        /// </summary>
        I10,
        /// <summary>
        /// special coding
        /// </summary>
        S,
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown
    }
}