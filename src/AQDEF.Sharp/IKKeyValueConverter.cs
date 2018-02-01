using System;

namespace AQDEF.Sharp {
    /// <summary>
    /// 
    /// </summary>
    public interface IKKeyValueConverter {

        object Convert(string value);

        string ToString(object value);
    }
}