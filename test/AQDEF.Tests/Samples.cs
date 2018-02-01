namespace AQDEF.Tests {
    internal static class Samples {
        public const string dfqWithString = @"
    K0100 1
    K1001/1 part
";

        public const string dfqWithInteger = @"
    K0100 1
    K1010/1 1
";

        public const string dfqWithDate = @"
    K0100 1
    K1001/1 part
    K2001/1 characteristic
    K0001/1 1
    K0004/1 1.1.2014/10:30:59
";

        public const string dfqWithEmptyKeys = @"
    K0100 1
    K1001/1 part
    K1002
    K1003/1
";

        public const string dfqWithUnindexedPart = @"
    K0100 1
    K1001 part
    K1002 title
";

        public const string dfqWithKeyAppliedToAllParts = @"
    K0100 2
    K1002/0 common title
    K1001/1 part1
    K1001/2 part2
";

        public const string dfqWithKeyAppliedToAllCharacteristics = @"
    K0100 2
    K1001/1 part
    K2002/0 common title
    K2001/1 characteristic1
    K2001/2 characteristic2
";

        public const string dfqWithKeyAppliedToAllCharacteristicsOnMultipleParts = @"
    K0100 4
    K1001/1 part1
    K2002/0 common title part1
    K2001/1 part1 - characteristic1
    K2001/2 part1 - characteristic2

    K1001/2 part2
    K2002/0 common title part2
    K2001/3 part2 - characteristic1
    K2001/4 part2 - characteristic2
";

        public const string dfqWithKeyAppliedToAllCharacteristicsOnOneOfMultipleParts = @"
    K0100 4
    K1001/1 part1
    K2002/0 common title
    K2001/1 part1 - characteristic1
    K2001/2 part1 - characteristic2

    K1001/2 part2
    K2001/3 part2 - characteristic1
    K2001/4 part2 - characteristic2
";

        /**
            * This behavior is not supported by qs-STAT but we can read such AQDEF.
            */

        public const string dfqWithKeyAppliedToAllValuesBeforeValue = @"
    K0100 1
    K1001/1 part
    K2001/1 characteristic1
    K0014/0 identifier
    K0001/1 1
    K0001/1 2
";

        public const string dfqWithKeyAppliedToSingleValueSet = @"
    K0100 1
    K1001/1 part
    K2001/1 characteristic1
    K0001/1 1
    K0014/0 identifier
    K0001/1 2
";

        public const string dfqWithKeyAppliedToEachValueSet = @"
    K0100 1
    K1001/1 part
    K2001/1 characteristic1
    K0001/1 1
    K0014/0 identifier 1
    K0001/1 2
    K0014/0 identifier 2
";

        public const string dfqWithMultipleKeysAppliedToAllValues = @"
    K0100 2
    K1001/1 part
    K2001/1 characteristic1
    K2001/2 characteristic2
    K0001/1 1
    K0001/2 3
    K0004/0 1.1.2014/10:30:59
    K0010/0 153
    K0014/0 common identifier
    K0001/1 2
    K0001/2 4
    K0004/0 1.1.2014/10:31:00
    K0010/0 154
    K0014/0 common identifier 2
";

        public const string dfqWithKeyAppliedToAllPartsSomeDefinedExplicitly = @"
    K0100 2
    K1002/0 common title
    K1001/1 part1
    K1002/1 explicit title
    K1001/2 part2
";

        public const string dfqWithTwoPartsWithBinaryValuesAtTheEnd = @"
    K0100 2
    K1001/1 part1
    K2001/1 characteristic1
    K2004/0 0
    K1001/2 part2
    K2001/2 characteristic2
    1001.01.2014/00:00:002001.01.2014/00:00:00
    1.1001.01.2014/00:00:002.1001.01.2014/00:00:00
";

        /**
            * Both values are for characteristic1 of part1.
            * (value sets could be written after each part but all characteristics are always considered when assigning values to characteristics)
            */

        public const string dfqWithTwoPartsWithBinaryValuesAfterEachPart = @"
    K0100 2
    K1001/1 part1
    K2001/1 characteristic1
    K2004/0 0
    1001.01.2014/00:00:00
    K1001/2 part2
    K2001/2 characteristic2
    2001.01.2014/00:00:00
";

        public const string dfqWithAttributeCharacteristicWithBinaryValues = @"
    K0100 2
    K1001/1 part1
    K2001/1 characteristic1
    K2004/1 0
    K2001/2 characteristic2
    K2004/2 1
    1001.01.2014/00:00:00100000001.01.2014/00:00:00
    1.1001.01.2014/00:00:00100010001.01.2014/00:00:00
";

        public const string dfqWithTwoPartsWithValuesAtTheEnd = @"
    K0100 2
    K1001/1 part1
    K2001/1 characteristic1
    K2004/0 0
    K1001/2 part2
    K2001/2 characteristic2
    K0001/1 1
    K0001/1 1.1
    K0001/2 2
    K0001/2 2.1
";

        public const string dfqWithTwoPartsWithValuesAfterEachPart = @"
    K0100 2
    K1001/1 part1
    K2001/1 characteristic1
    K2004/0 0
    K0001/1 1
    K0001/1 1.1
    K1001/2 part2
    K2001/2 characteristic2
    K0001/2 2
    K0001/2 2.1
";

        /**
            * Values are for 3 characteristics, but only 2 are defined
            */

        public const string dfqWithMoreValuesThanCharacteristics = @"
    K0100 2
    K1001/1 part1
    K2001/1 characteristic1
    K2001/2 characteristic2
    1001.01.2014/00:00:002001.01.2014/00:00:003001.01.2014/00:00:00
";

        public const string dfqWithKeyAppliedToAllPartsCharacteristicsAndValues = @"
K0100 2
K1001/0 common title
K1001/1 part
K2002/0 common title
K2001/1 characteristic
K0014/0 common identifier
K0001/1 1
";

        public const string dfqWithHierarchy = @"
K0100 2
K1001/1 part
K2001/1 characteristic 1
K2001/2 characteristic 2
K2001/3 characteristic 3
K2001/4 characteristic 4
K2001/5 characteristic 5
K2001/6 characteristic 6
K5001/1 group 1
K5001/1 group 1
K5111/1 1
K5112/2 1
K5112/3 2
K5112/4 3
K5112/5 4
K5112/6 5
K5112/7 6
K5113/8 1
K5102/1 1
K5103/1 3
K5102/3 3
K5102/3 4
K5103/1 8
K5102/8 5
K5102/8 6
";

        public const string dfqWithEmptySimpleAndNormalHierarchy = @"
K0100 2
K1001/1 part
K2001/1 characteristic 1
K2030/1 0
K2031/1 0
K2001/2 characteristic 2
K2030/2 0
K2031/2 0
K5111/1 1
K5112/2 1
K5112/3 2
K5102/1 1
K5102/1 2
";

        public const string dfqWithSimpleAndNormalHierarchy = @"
K0100 2
K1001/1 part
K2001/1 characteristic 1
K2030/1 1
K2031/1 0
K2001/2 characteristic 2
K2030/2 0
K2031/2 1
K5111/1 1
K5112/2 1
K5112/3 2
K5102/1 1
K5102/1 2
";

        public const string dfqWithAdditionalDataForLastValue = @"
K0100 2
K1001/1 part1
K2001/1 characteristic1
1001.01.2014/00:00:00
2001.01.2014/00:00:00
K0014/1 partId2
";

        public const string dfqWithAdditionalDataForValueWithIndex = @"
K0100 2
K1001/1 part1
K2001/1 characteristic1
1001.01.2014/00:00:00
2001.01.2014/00:00:00
K0014/1/1 partId1
";

        public const string dfqWithAdditionalDataForValueWithIndexAndAllCharacteristics = @"
K0100 2
K1001/1 part1
K2001/1 characteristic1
K2001/2 characteristic2
1001.01.2014/00:00:002001.01.2014/00:00:00
3001.01.2014/00:00:004001.01.2014/00:00:00
K0014/0/1 partId1
";

        public const string dfqWithAdditionalDataForAllValuesOfSingleCharacteristic = @"
K0100 2
K1001/1 part1
K2001/1 characteristic1
K2001/2 characteristic2
1001.01.2014/00:00:002001.01.2014/00:00:00
3001.01.2014/00:00:004001.01.2014/00:00:00
K0014/1/0 partId1
";

        public const string dfqWithValueIndexPlacedOnCharacteristicKKey = @"
K0100 2
K1001/1 part1
K2001/1 characteristic1
K2002/1/1 invalid characteristic name
1001.01.2014/00:00:00
2001.01.2014/00:00:00
";

        public const string dfqWithInvalidIndex = @"
K0100 2
K1001/1 part1
K2001/1-1 characteristic1
1001.01.2014/00:00:00
";

        public const string dfqWithEmptyValueIndex = @"
K0100 2
K1001/1 part1
K2001/1 characteristic1
1001.01.2014/00:00:00
K0014/1/ partId1
";
    }
}