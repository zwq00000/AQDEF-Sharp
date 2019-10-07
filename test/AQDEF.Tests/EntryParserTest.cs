using System;
using System.Globalization;
using System.IO;
using System.Linq;
using AQDEF.Sharp.Models;
using AQDEF.Models;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace AQDEF.Tests {
    [TestFixture]
    public class EntryParserTest {

        private AqdefModel Parse(string content) {
            var model = new AqdefModel();
            var reader = new StringReader(content);
            model.Parse(reader);
            return model;
        }

        [Test]
        public void TestKKeyLine() {
            var line = "K4000/0 Customer catalog";
            IKKeyEntry entry;
            Assert.True(EntryParser.ParseKKeyLine(line, out entry));
            Assert.NotNull(entry);
            Assert.Equal("K4000", entry.Key.Key);
            Assert.Equal(0, entry.Index);
            Assert.Equal("Customer catalog", entry.Text);
        }

        [Test]
        public void TestParseKKeyLine_NoIndex() {
            var line = "K1001 part";
            IKKeyEntry entry;
            Assert.True(EntryParser.ParseKKeyLine(line, out entry));
            Assert.NotNull(entry);
            Assert.Equal("K1001", entry.Key.Key);
            Assert.Equal(1, entry.Index);
            Assert.Equal("part", entry.Text);
        }

        [Test]
        public void TestParseSample() {
            var enties = EntryParser.Parse(Samples.dfqWithString).ToArray();
            Assert.NotEmpty(enties);

            enties = EntryParser.Parse("K1003").ToArray();
            Assert.NotEmpty(enties);
        }

        [Test(Description = "K-key entries of type String are parsed correctly")]
        public void Test_dfqWithString() {
            var model = Parse(Samples.dfqWithString);
            var part = model.GetPartEntries(1);
            Assert.Equal("part", part.PartNumber);
        }

        [Test(Description =  "K-key entries of type Integer are parsed correctly")]
        public void Test_dfqWithInteger() {
            var model =Parse(Samples.dfqWithInteger);
            Assert.NotEmpty(model.Parts);
            var part = model.Parts.First();
            Assert.NotNull(part);
            Assert.Equal(part.Entries.First(e => e.Key.Key == "K1010").Value,(byte)1);
        }

        [Test(Description =  "K-key entries of type Date are parsed correctly")]
        public void Test_dfqWithDate() {
            var model = Parse(Samples.dfqWithDate);
            Assert.NotNull(model);
            var entry = model.GetValueEntries(1,1,1);
            Assert.NotNull(entry);
            Assert.Equal(entry.GetValue("K0004"),new DateTime(2014,1,1,10,30,59));
        }

        [Test(Description =  "empty K-key entries are parsed correctly")]
        public void Test_dfqWithEmptyKeys() {
            var model = Parse(Samples.dfqWithEmptyKeys);

            var part = model.GetPartEntries(1);
            Assert.NotNull(part);

            Assert.Equal("part", part.GetValue("K1001"));
            Assert.Equal(string.Empty,part.GetValue("K1002"));
            Assert.Equal(string.Empty,part.GetValue("K1003"));
        }

        [Test]
        public void Test_dfqWithUnindexedPart() {
            var model = Parse(Samples.dfqWithUnindexedPart);

            var part = model.Parts;
            Assert.NotNull(part);

            Assert.Equal("part", part.GetValue("K1001"));
            Assert.Equal("title", part.GetValue("K1002"));
        }

        [Test(Description =  "/0 part entries are applied to all parts")]
        public void Test_dfqWithKeyAppliedToAllParts() {
            var model = Parse(Samples.dfqWithKeyAppliedToAllParts);
            
            Assert.Equal(2, model.Parts.Count());
            var part0 = model.Parts[0];
            var part1 = model.Parts[1];
            var part2 = model.Parts[2];

            Assert.Equal("common title", part1.GetValue("K1002"));
            Assert.Equal("common title", part2.GetValue("K1002"));
            Assert.Null(part0);
        }

        [Fact(DisplayName= "/0 characteristic entries are applied to all characteristics when there are multiple parts")]
        public void Test_dfqWithKeyAppliedToAllCharacteristicsOnMultipleParts() {
            var model = Parse(Samples.dfqWithKeyAppliedToAllCharacteristicsOnMultipleParts);

            var part1char1 = model.Parts[1].Characteristics[1];
            var part1char2 = model.Parts[1].Characteristics[2];

            var part2char1 = model.Parts[2].Characteristics[3];//(2, 3)
            var part2char2 = model.Parts[2].Characteristics[4];//(2, 4)

            var part1char0 = model.Parts[1].Characteristics[0];//(1, 0)
            var part2char0 = model.Parts[2].Characteristics[0];//(2, 0)

            Assert.Equal("common title part2", part1char1.GetValue("K2002"));
            Assert.Equal("common title part2", part1char2.GetValue("K2002"));
            Assert.Equal("common title part2", part2char1.GetValue("K2002"));
            Assert.Equal("common title part2", part2char2.GetValue("K2002"));
            Assert.Null(part1char0);
            Assert.Null(part2char0);
        }

        [Test(Description =  "/0 characteristic entries are applied to all characteristics of single part when there are multiple parts")]
        public void Test_dfqWithKeyAppliedToAllCharacteristicsOnOneOfMultipleParts() {
            var model = Parse(Samples.dfqWithKeyAppliedToAllCharacteristicsOnOneOfMultipleParts);

            var part1char1 = model.Parts[1].Characteristics[1];//(1, 1);
            var part1char2 = model.Parts[1].Characteristics[2];//(1, 2);

            var part2char1 = model.Parts[2].Characteristics[3];//(2, 3);
            var part2char2 = model.Parts[2].Characteristics[4];//(2, 4);

            Assert.Equal("common title", part1char1.GetValue("K2002"));
            Assert.Equal("common title", part1char2.GetValue("K2002"));
            Assert.Equal("common title", part2char1.GetValue("K2002"));
            Assert.Equal("common title", part2char2.GetValue("K2002"));
        }

        [Test(Description =  "/0 value entry is applied to first value set when the common entry is written before values")]
        public void Test_dfqWithKeyAppliedToAllValuesBeforeValue() {
            var model = Parse(Samples.dfqWithKeyAppliedToAllValuesBeforeValue);

            var entries1 = model.GetValueEntries(1, 1, 1);
            var entries2 = model.GetValueEntries(1, 1, 2);

            var entries0 = model.GetValueEntries(1, 0, 0);

            Assert.Equal("identifier",entries1.GetValue("K0014"));
            Assert.Null(entries2.GetValue("K0014"));
            Assert.Null(entries0);
        }

        [Test(Description =  "/0 value entry is applied to a single value")]
        public void Test_dfqWithKeyAppliedToSingleValueSet() {
            var model = Parse(Samples.dfqWithKeyAppliedToSingleValueSet);

            var entries1 = model.Parts[1].Characteristics[1].Values[1];//.getValueEntries(1, 1, 1)
            var entries2 = model.Parts[1].Characteristics[2].Values[2];//.getValueEntries(1, 1, 2)

            var entries0 = model.Parts[1].Characteristics[0];//.getValueEntries(1, 0, 0)

            //entries1.getValue("K0014") == "identifier"
            Assert.Equal("identifier", entries1.GetValue("K0014"));
            //entries2.getValue("K0014") == null
            Assert.Null(entries2.GetValue("K0014"));

            //entries0 == null
            Assert.Null(entries0);
        }

        [Test(Description =  "/0 value entry is applied to multiple values")]
        public void Test_dfqWithKeyAppliedToEachValueSet() {
            var model = Parse(Samples.dfqWithKeyAppliedToEachValueSet);

            var entries1 = model.GetValueEntries(1, 1, 1);
            var entries2 = model.GetValueEntries(1, 1, 2);

            var entries0 = model.GetValueEntries(1, 0, 0);

            // entries1.getValue("K0014") == "identifier 1"
            Assert.Equal("identifier 2", entries1.GetValue("K0014"));
            // entries2.getValue("K0014") == "identifier 2"
            Assert.Equal("identifier 2", entries2.GetValue("K0014"));
            // entries0 == null
            Assert.Null(entries0);
        }

        [Test(Description =  "/0 value entries are applied to multiple values")]
        public void Test_dfqWithMultipleKeysAppliedToAllValues() {
            var model = Parse(Samples.dfqWithMultipleKeysAppliedToAllValues);

            var char1Value1 = model.GetValueEntries(1, 1, 1);
            var char1Value2 = model.GetValueEntries(1, 1, 2);

            var char2Value1 = model.GetValueEntries(1, 2, 1);
            var char2Value2 = model.GetValueEntries(1, 2, 2);

            var entries0 = model.GetValueEntries(1, 0, 0);
            IFormatProvider formatProvider = new CultureInfo("en-US");

            //char1Value1.getValue("K0004") == Date.parse("dd.MM.yyyy HH:mm:ss", "1.1.2014 10:30:59")
            Assert.Equal(DateTime.ParseExact("1.1.2014 10:30:59","d.M.yyyy HH:mm:ss",formatProvider), char1Value1.GetValue("K0004"));
            //char1Value1.GetValue("K0010") == 153i
            Assert.Equal(153, char1Value1.GetValue("K0010"));
            //char1Value1.GetValue("K0014") == "common identifier"
            Assert.Equal("common identifier", char1Value1.GetValue("K0014"));

            //char1Value2.GetValue("K0004") == Date.parse("dd.MM.yyyy HH:mm:ss", "1.1.2014 10:31:00")
            Assert.Equal(DateTime.ParseExact("1.1.2014 10:31:00", "d.M.yyyy HH:mm:ss",formatProvider), char1Value2.GetValue("K0004"));
            //char1Value2.GetValue("K0010") == 154i
            Assert.Equal(154, char1Value2.GetValue("K0010"));
            //char1Value2.GetValue("K0014") == "common identifier 2"
            Assert.Equal("common identifier 2", char1Value2.GetValue("K0014"));

            //char2Value1.GetValue("K0004") == Date.parse("dd.MM.yyyy HH:mm:ss", "1.1.2014 10:30:59")
            Assert.Equal(DateTime.ParseExact("1.1.2014 10:30:59", "d.M.yyyy HH:mm:ss",formatProvider), char2Value1.GetValue("K0004"));
            //char2Value1.GetValue("K0010") == 153i
            Assert.Equal(153, char2Value1.GetValue("K0010"));
            //char2Value1.GetValue("K0014") == "common identifier"
            Assert.Equal("common identifier", char2Value1.GetValue("K0014"));

            //char2Value2.GetValue("K0004") == Date.parse("dd.MM.yyyy HH:mm:ss", "1.1.2014 10:31:00")
            Assert.Equal(DateTime.ParseExact("1.1.2014 10:31:00", "d.M.yyyy HH:mm:ss",formatProvider), char2Value2.GetValue("K0004"));
            //char2Value2.GetValue("K0010") == 154i
            Assert.Equal(154, char2Value2.GetValue("K0010"));
            //char2Value2.GetValue("K0014") == "common identifier 2"
            Assert.Equal("common identifier 2", char2Value2.GetValue("K0014"));

            //entries0 == null
            Assert.Null(entries0);
        }

        [Test(Description =  "/0 entries don't overwrites explicitly defined entries")]
        public void Test_dfqWithKeyAppliedToAllPartsSomeDefinedExplicitly() {
            var model = Parse(Samples.dfqWithKeyAppliedToAllPartsSomeDefinedExplicitly);

            var entries1 = model.GetPartEntries(1);
            var entries2 = model.GetPartEntries(2);

            //entries1.getValue("K1002") == "explicit title"
            Assert.Equal("explicit title", entries1.GetValue("K1002"));
            //entries2.getValue("K1002") == "common title"
            Assert.Equal("common title", entries2.GetValue("K1002"));
        }


        [Test(Description =  "values in binary format are parsed correctly - values are at the end")]
        public void Test_dfqWithTwoPartsWithBinaryValuesAtTheEnd() {
            var model = Parse(Samples.dfqWithTwoPartsWithBinaryValuesAtTheEnd);

            var values1 = model.GetValueEntries(1,1,1);
            var values2 = model.GetValueEntries(2,2,1);

            Assert.Equal(2, values1.Entries.Count());
            Assert.Equal(2, values2.Entries.Count());
        }

        /*
        [Test(Description =  "values in binary format are parsed correctly - values are after each part")]
        public void Test_dfqWithTwoPartsWithBinaryValuesAfterEachPart() {
            var model = Parse(Samples.dfqWithTwoPartsWithBinaryValuesAfterEachPart);

            var values1 = model.GetValueEntries(1,1);
            var values2 = model.GetValueEntries(2,2);

            values1.size() == 2
            values2.size() == 0
        }*/

        [Test(Description =  "single continuous and single atribute characteristic with values in binary format are parsed correctly")]
        public void Test_dfqWithAttributeCharacteristicWithBinaryValues() {
            var model = Parse(Samples.dfqWithAttributeCharacteristicWithBinaryValues);

            var char1Value1 = model.GetValueEntries(1, 1, 1);
            var char1Value2 = model.GetValueEntries(1, 1, 2);
            var char2Value1 = model.GetValueEntries(1, 2, 1);
            var char2Value2 = model.GetValueEntries(1, 2, 2);

            //char1Value1.GetValue("K0001") == 1
            Assert.Equal(1, char1Value1.GetValue("K0001"));
            //char1Value2.GetValue("K0001") == 1.1
            Assert.Equal(1.1, char1Value2.GetValue("K0001"));

            //char2Value1.GetValue("K0020") == 1
            Assert.Equal(1, char2Value1.GetValue("K0020"));
            //char2Value1.GetValue("K0021") == 0
            Assert.Equal(0, char2Value1.GetValue("K0021"));
            //char2Value2.GetValue("K0020") == 1
            Assert.Equal(1, char2Value2.GetValue("K0020"));
            //char2Value2.GetValue("K0021") == 1
            Assert.Equal(1, char2Value2.GetValue("K0021"));
        }

        /*
        [Test(Description =  "values in K-key format are parsed correctly - values are at the end")]
        public void Test_dfqWithTwoPartsWithValuesAtTheEnd() {
            var model = Parse(Samples.dfqWithTwoPartsWithValuesAtTheEnd);

            var values1 = model.GetValueEntries(CharacteristicIndex.of(1, 1));
            var values2 = model.GetValueEntries(CharacteristicIndex.of(2, 2));

            values1.size() == 2
            values2.size() == 2
        }

        [Test(Description =  "values in K-key format are parsed correctly - values are after each part")]
        public void Test_dfqWithTwoPartsWithValuesAfterEachPart() {
            var model = Parse(Samples.dfqWithTwoPartsWithValuesAfterEachPart);

            var values1 = model.GetValueEntries(1, 1);
            var values2 = model.GetValueEntries(2, 2);

            values1.size() == 2
            values2.size() == 2
        }*/

        [Test(Description =  "error is thrown when there are values for non-existing characteristic")]
        public void Test_dfqWithMoreValuesThanCharacteristics() {
            Assert.Throws<Exception>(() => {
                var model = Parse(Samples.dfqWithMoreValuesThanCharacteristics);
            });
        }

        /*
        [Test(Description =  "there are no /0 entries after aqdef object model normalization")]
        public void Test_dfqWithKeyAppliedToAllPartsCharacteristicsAndValues() {
            var model = Parse(Samples.dfqWithKeyAppliedToAllPartsCharacteristicsAndValues);

            var parts = model.partEntries[PartIndex.of(0)];
            var characteristics = model.characteristicEntries.Get(PartIndex.of(0));
            var values = model.valueEntries[PartIndex.of(0)];

            parts == null
            characteristics == null
            values == null
        }

        [Test(Description =  "hierarchy si parsed correctly")]
        public void Test_dfqWithHierarchy() {
            var model = Parse(Samples.dfqWithHierarchy);

            var nodeDefinitions = model.hierarchy.nodeDefinitions;
            var partBindings = model.hierarchy.nodeBindings.Get(NodeIndex.of(1));
            var characteristicBindings = model.hierarchy.nodeBindings.Get(NodeIndex.of(3));
            var groupBindings = model.hierarchy.nodeBindings.Get(NodeIndex.of(8));

            nodeDefinitions.size() == 8
            partBindings.size() == 3
            characteristicBindings.size() == 2
            groupBindings.size() == 2
        }
        
        [Test(Description =  "hierarchy could be parsed even when there are both empty simple hierarchy and normal hierarchy")]
        public void Test_dfqWithEmptySimpleAndNormalHierarchy() {
            var model = Parse(Samples.dfqWithEmptySimpleAndNormalHierarchy);

            var nodeDefinitions = model.hierarchy.nodeDefinitions;
            var partBindings = model.hierarchy.nodeBindings.Get(NodeIndex.of(1));

            nodeDefinitions.size() == 3
            partBindings.size() == 2
            model.hierarchy.nodeBindings.size() == 1
        }
        */

        [Test(Description =  "hierarchy could not be parsed when there are both simple and normal hierarchy (both non-empty)")]
        public void Test_dfqWithSimpleAndNormalHierarchy() {
            Assert.Throws<Exception>(() => {
                var model = Parse(Samples.dfqWithSimpleAndNormalHierarchy);
            });
        }

        [Test(Description =  "additional data are assigned to the value that preceeds the additional data definition")]
        public void Test_dfqWithAdditionalDataForLastValue() {
            var model = Parse(Samples.dfqWithAdditionalDataForLastValue);

            var entries1 = model.GetValueEntries(1, 1, 1);
            var entries2 = model.GetValueEntries(1, 1, 2);

            //entries1.GetValue("K0014") == null
            //entries2.GetValue("K0014") == "partId2"
            //todo: 和Java 版正好相反，enties2 == null;
            Assert.Equal("partId2", entries1.GetValue("K0014"));
            Assert.Null(entries2.GetValue("K0014"));

        }

        [Test(Description =  "additional data with value index are assigned to the right value")]
        public void Test_dfqWithAdditionalDataForValueWithIndex() {
            var model = Parse(Samples.dfqWithAdditionalDataForValueWithIndex);

            var entries1 = model.GetValueEntries(1, 1, 1);
            var entries2 = model.GetValueEntries(1, 1, 2);

            //entries1.GetValue("K0014") == "partId1"
            Assert.Equal("partId1", entries1.GetValue("K0014"));
            //entries2.GetValue("K0014") == null
            Assert.Null(entries2.GetValue("K0014"));

        }

        [Test(Description =  "additional data with value index for all characteristics (/0) are assigned to the right values")]
        public void Test_dfqWithAdditionalDataForValueWithIndexAndAllCharacteristics() {
            var model = Parse(Samples.dfqWithAdditionalDataForValueWithIndexAndAllCharacteristics);

            var value1ofCharacteristic1 = model.GetValueEntries(1, 1, 1);
            var value2ofCharacteristic1 = model.GetValueEntries(1, 1, 2);
            var value1ofCharacteristic2 = model.GetValueEntries(1, 2, 1);
            var value2ofCharacteristic2 = model.GetValueEntries(1, 2, 2);

            //value1ofCharacteristic1.GetValue("K0014") == "partId1"
            Assert.Equal("partId1", value1ofCharacteristic1.GetValue("K0014"));
            //value1ofCharacteristic2.GetValue("K0014") == "partId1"
            Assert.Equal("partId1",value1ofCharacteristic2.GetValue("K0014"));
            //value2ofCharacteristic1.GetValue("K0014") == null
            Assert.Null(value2ofCharacteristic1.GetValue("K0014"));
            //value2ofCharacteristic2.GetValue("K0014") == null
            Assert.Null(value2ofCharacteristic2.GetValue("K0014"));

        }

        //@Ignore // this functionality is not implemented
            [Test(Description =  "additional data with value index for all values of single characteristics are assigned to the right values")]
        public void Test_dfqWithAdditionalDataForAllValuesOfSingleCharacteristic() {
            var model = Parse(Samples.dfqWithAdditionalDataForAllValuesOfSingleCharacteristic);

            var value1ofCharacteristic1 = model.GetValueEntries(1, 1, 1);
            var value2ofCharacteristic1 = model.GetValueEntries(1, 1, 2);
            var value1ofCharacteristic2 = model.GetValueEntries(1, 2, 1);
            var value2ofCharacteristic2 = model.GetValueEntries(1, 2, 2);

            //value1ofCharacteristic1.GetValue("K0014") == "partId1"
            Assert.Equal("partId1", value1ofCharacteristic1.GetValue("K0014"));
            //value2ofCharacteristic1.GetValue("K0014") == "partId1"
            Assert.Equal("partId1", value2ofCharacteristic1.GetValue("K0014"));
            //value1ofCharacteristic2.GetValue("K0014") == null
            Assert.Null(value1ofCharacteristic2.GetValue("K0014"));
            //value2ofCharacteristic2.GetValue("K0014") == null
            Assert.Null(value2ofCharacteristic2.GetValue("K0014"));

        }

        [Test(Description =  "value index can be placed only on value k-keys")]
        public void Test_dfqWithValueIndexPlacedOnCharacteristicKKey() {
            Assert.Throws<Exception>(() => {
                var model = Parse(Samples.dfqWithValueIndexPlacedOnCharacteristicKKey);
            });
        }

        [Test(Description =  "invalid index will cause exception")]
        public void Test_dfqWithInvalidIndex() {
            Assert.Throws<Exception>(() => {
                var model = Parse(Samples.dfqWithInvalidIndex);
            });
        }

        [Test(Description =  "empty value index will cause exception")]
        public void Test_dfqWithEmptyValueIndex() {
            Assert.Throws<Exception>(() => {
                var model = Parse(Samples.dfqWithEmptyValueIndex);
            });
        }
    }
}