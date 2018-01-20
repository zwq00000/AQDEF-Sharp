using System;

namespace AQDEF.Sharp {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IKKeyValueConverter<T> : IKKeyValueConverter where T: IConvertible {

        T convert(string value);

        String toString(T value);
    }

    public interface IKKeyValueConverter {

        object convert(string value);

        string toString(object value);
    }
}