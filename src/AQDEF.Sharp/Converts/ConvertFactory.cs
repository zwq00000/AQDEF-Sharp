namespace AQDEF.Sharp.Converts {
    public static class ConvertFactory {
        private static readonly StringKKeyValueConverter StringConverter = new StringKKeyValueConverter();
        private static readonly DateKKeyValueConverter DateConverter = new DateKKeyValueConverter();
        private static readonly BigDecimalKKeyValueConverter DecimalConverter = new BigDecimalKKeyValueConverter();
        private static BooleanKKeyValueConverter _boolConverter = new BooleanKKeyValueConverter();
        private static readonly IntegerKKeyValueConverter IntConverter = new IntegerKKeyValueConverter();
        private static readonly ShortKKeyValueConverter ShortConverter = new ShortKKeyValueConverter();
        private static readonly ByteKKeyValueConverter ByteConverter = new ByteKKeyValueConverter();
        public static IKKeyValueConverter GetConverter(KKeyFieldType valueType) {
            switch (valueType) {
                case KKeyFieldType.A:
                    return StringConverter;
                case KKeyFieldType.I3:
                    return ByteConverter;
                case KKeyFieldType.I5:
                    return ShortConverter;
                case KKeyFieldType.I10:
                    return IntConverter;
                case KKeyFieldType.D:
                    return DateConverter;
                case KKeyFieldType.F:
                    return DecimalConverter;
                case KKeyFieldType.S:
                case KKeyFieldType.Unknown:
                default:
                    return StringConverter;
            }

        }
    }
}