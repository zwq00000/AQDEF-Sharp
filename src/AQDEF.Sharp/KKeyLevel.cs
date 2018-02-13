using System;

namespace AQDEF.Sharp {
    [Flags]
    public enum KKeyLevel {
        PART,
        CHARACTERISTIC,
        VALUE,
        CUSTOM_PART,
        CUSTOM_CHARACTERISTIC,
        CUSTOM_VALUE,
        GROUP,
        HIERARCHY,
        SIMPLE_HIERARCHY,
        CATALOG,
        UNKNOWN
    }
}