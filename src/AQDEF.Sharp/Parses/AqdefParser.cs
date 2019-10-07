using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AQDEF.Sharp.AQDEFModels;
using AQDEF.Sharp.Models;

namespace AQDEF.Sharp.Parses
{
    /// <summary>
    /// Parses <seealso cref="AqdefObjectModel"/> from a AQDEF content (file or other data source).
    /// 
    /// @author Vlastimil Dolejs
    /// 
    /// </summary>
    public class AqdefParser {
        //*******************************************
        // Attributes
        //*******************************************

        private static readonly Logger Log = new Logger(typeof(AqdefParser));

        private const string IgnoredBinaryKey = "ignore";

        private static readonly string[] BinaryValuePortions = new string[] { "K0001", "K0002", "K0004", "K0005", "K0006", "K0007", "K0008", "K0010", "K0011", "K0012" };

        private static readonly string[] BinaryAttributeValuePortions = new string[] { "K0020", "K0021", IgnoredBinaryKey, "K0002", "K0004", "K0005", "K0006", "K0007", "K0008", "K0010", "K0011", "K0012" };

        /// <summary>
        /// These keys does not contain any information and we can safely ignore them.
        /// </summary>
        private static readonly string[] IgnoredKeys = new string[] { "K0100", "K100", "K0101", "K101" };

        /// <summary>
        /// These keys contain Q-DAS qs-STAT properietary internal configuration so we can safely ignore them.
        /// </summary>
        private static readonly string[] ProprietaryQdasKeys = new string[] { "K1998", "K2998", "K2999", "K5098", "K5080" };

        private readonly KKeyRepository _kKeyRepository;

        //*******************************************
        // Constructors
        //*******************************************

        public AqdefParser() {
            this._kKeyRepository = KKeyRepository.getInstance();
        }

        //*******************************************
        // Methods
        //*******************************************

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public cz.diribet.aqdef.model.AqdefObjectModel parse(String content) throws java.io.IOException
        public virtual AqdefObjectModel Parse(string content) {
            return Parse(new StringReader(content));
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public cz.diribet.aqdef.model.AqdefObjectModel parse(java.nio.file.Path file, String encoding) throws java.io.IOException
        public virtual AqdefObjectModel Parse(string filepath,Encoding encoding) {
            return Parse(File.OpenRead(filepath), encoding);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public cz.diribet.aqdef.model.AqdefObjectModel parse(java.io.File file, String encoding) throws java.io.IOException
        public virtual AqdefObjectModel Parse(FileInfo file, Encoding encoding) {
            using (System.IO.Stream stream = file.OpenRead()) {
                return Parse(stream, encoding);
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public cz.diribet.aqdef.model.AqdefObjectModel parse(java.io.InputStream inputStream, String encoding) throws java.io.IOException
        public virtual AqdefObjectModel Parse(Stream inputStream, Encoding encoding) {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(inputStream,encoding)) {
                return Parse(reader);
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public cz.diribet.aqdef.model.AqdefObjectModel parse(java.io.Reader reader) throws java.io.IOException
        public virtual AqdefObjectModel Parse(TextReader reader) {
            AqdefObjectModel aqdefObjectModel = new AqdefObjectModel();
            ParserContext context = new ParserContext();

            int lineIndex = 0;
                string line;
                while ((line = reader.ReadLine())!=null) {
                    context.CurrentLine = lineIndex;
                    try {
                        line = line.Trim();

                        if (!string.IsNullOrWhiteSpace(line)) {
                            ParseLine(line, aqdefObjectModel, context);
                        }
                    } catch (Exception e) {
                        throw new DfqParserException(context, e);
                    }

                    lineIndex++;
                }

            aqdefObjectModel.normalize();

            return aqdefObjectModel;
        }


        private void ParseLine(string line, AqdefObjectModel aqdefObjectModel, ParserContext context) {
            if (IsKKeyLine(line)) {
                ParseKKeyLine(line, aqdefObjectModel, context);
            } else if (IsBinaryDataLine(line)) {
                ParseBinaryDataLine(line, aqdefObjectModel, context);
            } else {
                Log.warn("{} Invalid line format. This line will be discarded. Line content: {}", LineLogContext(context), line);
            }
        }

        private bool IsKKeyLine(string line) {
            return line.StartsWith("K", StringComparison.Ordinal);
        }

        private bool IsBinaryDataLine(string line) {
            return line.IndexOf(AqdefConstants.MEASURED_VALUES_DATA_SEPARATOR) >= 0;
        }

        private void ParseKKeyLine(string line, AqdefObjectModel aqdefObjectModel, ParserContext context) {
            if (ShouldIgnoreKKeyLine(line)) {
                return;
            }

            string key = line.Substring(0, 5);
            KKey kKey = KKey.Of(key);

            bool hasIndex = false;
            if (line.Length > 5) {
                hasIndex = line[5] == '/';
            }

            int firstSpaceIndex = line.IndexOf(" ", 5, StringComparison.Ordinal);
            if (firstSpaceIndex == -1) {
                firstSpaceIndex = line.Length;
            }

            int index = 1;
            int? valueIndexNumber = null;
            if (hasIndex) {
                string indexString = line.Substring(6, firstSpaceIndex - 6);
                if (string.IsNullOrWhiteSpace(indexString)) {
                    int valueIndexSeparatorPosition = indexString.IndexOf("/", StringComparison.Ordinal);
                    if (valueIndexSeparatorPosition == -1) {
                        try {
                            index = Convert.ToInt32(indexString);
                        } catch (System.FormatException e) {
                            throw new AqdefValidityException("K-key index is invalid: " + indexString, e);
                        }
                    } else {
                        if (kKey.IsValueLevel) {
                            try {
                                index = Convert.ToInt32(indexString.Substring(0, valueIndexSeparatorPosition));
                                valueIndexNumber = Convert.ToInt32(indexString.Substring(valueIndexSeparatorPosition + 1));
                            } catch (System.FormatException e) {
                                throw new AqdefValidityException("K-key index is invalid: " + indexString, e);
                            }
                        } else {
                            throw new AqdefValidityException("K-key index (" + indexString + ") contains a value index but the K-key (" + kKey + ") is not a value key.");
                        }
                    }
                }
            }

            string valueString = line.Substring(firstSpaceIndex).Trim();

            object value;
            try {
                value = ConvertValue(kKey, valueString, context);
            } catch (Exception e) when (e is UnknownKKeyException || e is ValueConversionException) {
                //TODO: 2016/04/11 - vlasta: we should provide information that parsed AqdefObjectModel doesn't contain all data?
                value = null;
            }

            if (value == null) {
                return;
            }

            if (kKey.IsPartLevel) {  //部件层

                PartIndex partIndex = PartIndex.Of(index);
                aqdefObjectModel.putPartEntry(kKey, partIndex, value);

                context.CurrentPartIndex = partIndex;

            } else if (kKey.IsCharacteristicLevel) {  //检测特征层

                PartIndex partIndex;
                if (index == 0) {
                    partIndex = PartIndex.Of(0);
                } else {
                    partIndex = context.CurrentPartIndex;
                    if (partIndex == null || partIndex.Index == null || partIndex.Index == 0) {
                        // no part k-key found before this characteristic - add it to the first part
                        partIndex = PartIndex.Of(1);
                    }
                }
                CharacteristicIndex characteristicIndex = CharacteristicIndex.of(partIndex, index);

                aqdefObjectModel.putCharacteristicEntry(kKey, characteristicIndex, value);

            } else if (kKey.IsGroupLevel) {     //分组层

                PartIndex partIndex;
                if (index == 0) {
                    partIndex = PartIndex.Of(0);
                } else {
                    partIndex = context.CurrentPartIndex;
                    if (partIndex == null || partIndex.Index == null || partIndex.Index == 0) {
                        // no part k-key found before this group - add it to the first part
                        partIndex = PartIndex.Of(1);
                    }
                }
                GroupIndex groupIndex = GroupIndex.Of(partIndex, index);

                aqdefObjectModel.putGroupEntry(kKey, groupIndex, value);

            } else if (kKey.IsValueLevel) {     //数值层

                PartIndex partIndex;
                if (index == 0) {
                    partIndex = PartIndex.Of(0);
                } else {
                    partIndex = aqdefObjectModel.findPartIndexForCharacteristic(index);
                    if (partIndex == null) {
                        throw new AqdefValidityException("Characteristic with index " + index + " was not found. Can't parse value.");
                    }
                }
                CharacteristicIndex characteristicIndex = CharacteristicIndex.of(partIndex, index);
                ValueIndex valueIndex;
                if (valueIndexNumber == null) {
                    valueIndex = context.ValueIndexCounter.GetIndex(characteristicIndex, kKey);
                } else {
                    valueIndex = ValueIndex.Of(characteristicIndex, valueIndexNumber);
                }

                aqdefObjectModel.putValueEntry(kKey, valueIndex, value);

            } else if (kKey.IsHierarchyLevel || kKey.IsSimpleHierarchyLevel) {

                aqdefObjectModel.putHierarchyEntry(kKey, index, value);

            } else {

                Log.warn("{} Unknown level of k-key {}. Key will be ignored! ", LineLogContext(context), kKey.Key);

            }
        }

        private bool ShouldIgnoreKKeyLine(string line) {
            if (line.Length < 5) {
                return true;
            }

            foreach (string ignoredKey in IgnoredKeys) {
                if (line.StartsWith(ignoredKey + " ", StringComparison.Ordinal) || line.StartsWith(ignoredKey + "/", StringComparison.Ordinal)) {
                    return true;
                }
            }

            foreach (string proprietaryKey in ProprietaryQdasKeys) {
                if (line.StartsWith(proprietaryKey, StringComparison.Ordinal)) {
                    return true;
                }
            }

            return false;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: private Object convertValue(cz.diribet.aqdef.KKey key, String valueString, ParserContext context) throws UnknownKKeyException, ValueConversionException
        private object ConvertValue(KKey key, string valueString, ParserContext context) {
            if (string.IsNullOrWhiteSpace(valueString)) {
                return null;
            }

            KKeyMetadata kKeyMetadata = _kKeyRepository.GetMetadataFor(key);
            if (kKeyMetadata == null) {
                Log.warn("{} Unknown k-key: {}. Value will be discarded.", LineLogContext(context), key.Key);
                throw new UnknownKKeyException(key);
            }

            //JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
            //ORIGINAL LINE: cz.diribet.aqdef.convert.IKKeyValueConverter<?> converter = kKeyMetadata.getConverter();
            var converter = kKeyMetadata.Converter;

            try {

                return converter.Convert(valueString);

            } catch (Exception e) {
                Log.warn($"{LineLogContext(context)} Failed to convert value: {valueString} of K-key: {key} using converter: {converter}. The value will be discarded.", e);
                throw new ValueConversionException(valueString, key, converter, e);
            }
        }

        private void ParseBinaryDataLine(string line, AqdefObjectModel aqdefObjectModel, ParserContext context) {
            string[] characteristicPortions = line.Split(AqdefConstants.MEASURED_VALUES_CHARACTERISTIC_SEPARATOR);

            int characteristicIntIndex = 1;
            foreach (string characteristicPortion in characteristicPortions) {
                string[] dataPortions = characteristicPortion.Split(AqdefConstants.MEASURED_VALUES_DATA_SEPARATOR);

                PartIndex partIndex = aqdefObjectModel.findPartIndexForCharacteristic(characteristicIntIndex);
                if (partIndex == null) {
                    throw new AqdefValidityException("Characteristic with index " + characteristicIntIndex + " was not found. Can't parse value.");
                }
                CharacteristicIndex characteristicIndex = CharacteristicIndex.of(partIndex, characteristicIntIndex);

                // recognize binary value format for characterstic type
                bool? isAttributeCharacteristic = null;
                CharacteristicEntries characteristicEntries = aqdefObjectModel.getCharacteristicEntries(characteristicIndex);
                if (characteristicEntries != null) {
                    int? characteristicType = characteristicEntries.getValue<int?>(KKey.Of("K2004"));

                    if (characteristicType != null) {
                        if (characteristicType == 1 || characteristicType == 5 || characteristicType == 6) { // 1 - attribute / 5, 6 - error log sheet
                            isAttributeCharacteristic = true;
                        } else {
                            isAttributeCharacteristic = false;
                        }
                    }
                }

                // if the information about characteristic type is not available, then try to guess it from binary portion count
                if (isAttributeCharacteristic == null) {
                    isAttributeCharacteristic = dataPortions.Length > 10; // attribute values has more than 10 portions
                }

                string[] dataPortionKeys;
                if (isAttributeCharacteristic.Value) {
                    dataPortionKeys = BinaryAttributeValuePortions;
                } else {
                    dataPortionKeys = BinaryValuePortions;
                }

                for (int i = 0; i < dataPortions.Length; i++) {
                    string dataPortion = dataPortions[i];
                    string key = dataPortionKeys[i];

                    if (string.ReferenceEquals(key, IgnoredBinaryKey)) {
                        continue;
                    }

                    KKey kKey = KKey.Of(key);

                    object value;
                    try {
                        value = ConvertValue(kKey, dataPortion, context);
                    } catch (Exception e) when (e is UnknownKKeyException || e is ValueConversionException) {
                        //TODO: 2016/04/11 - vlasta: we should provide information that parsed AqdefObjectModel doesn't contain all data?
                        value = null;
                    }

                    if (value != null) {
                        ValueIndex valueIndex = context.ValueIndexCounter.GetIndex(characteristicIndex, kKey);

                        aqdefObjectModel.putValueEntry(kKey, valueIndex, value);
                    }
                }

                characteristicIntIndex++;
            }
        }

        private string LineLogContext(ParserContext context) {
            return (new StringBuilder()).Append("Line ").Append(context.CurrentLine).Append(":").ToString();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: private java.io.InputStream createFileInputStream(java.io.File file, String encoding) throws java.io.FileNotFoundException
        private System.IO.Stream CreateFileInputStream(FileInfo file, string encoding) {
            System.IO.Stream inputStream = file.OpenRead();
            return inputStream;
        }

        //*******************************************
        // Inner classes
        //*******************************************

        /// <summary>
        /// @author Vlastimil Dolejs
        /// 
        /// </summary>
        private class ValueIndexCounter {
            internal readonly IDictionary<CharacteristicIndex, ISet<KKey>> Keys = new Dictionary<CharacteristicIndex, ISet<KKey>>();
            internal readonly IDictionary<CharacteristicIndex, int?> Indexes = new Dictionary<CharacteristicIndex, int?>();

            public virtual ValueIndex GetIndex(CharacteristicIndex characteristicIndex, KKey key) {
                ISet<KKey> keysOfCurrentValue = Keys.GetValueOrNull(characteristicIndex);

                if (keysOfCurrentValue == null) {
                    keysOfCurrentValue = new HashSet<KKey>();
                    Keys[characteristicIndex] = keysOfCurrentValue;
                }

                int? currentIndex = Indexes.GetValueOrNull(characteristicIndex);
                currentIndex = currentIndex == null ? 1 : currentIndex;

                if (keysOfCurrentValue.Contains(key)) {
                    // this key was already parsed, so it is new value
                    keysOfCurrentValue.Clear();
                    currentIndex++;
                    Indexes[characteristicIndex] = currentIndex;
                }
                keysOfCurrentValue.Add(key);

                return ValueIndex.Of(characteristicIndex, currentIndex);
            }
        }

        /// <summary>
        /// @author Vlastimil Dolejs
        /// 
        /// </summary>
        private class ParserContext {
            private int _currentLine;
            private PartIndex _currentPartIndex;
            private readonly ValueIndexCounter _valueIndexCounter = new ValueIndexCounter();

            public virtual int CurrentLine {
                get {
                    return _currentLine;
                }
                set {
                    this._currentLine = value;
                }
            }


            public virtual PartIndex CurrentPartIndex {
                get {
                    return _currentPartIndex;
                }
                set {
                    this._currentPartIndex = value;
                }
            }


            public virtual ValueIndexCounter ValueIndexCounter {
                get {
                    return _valueIndexCounter;
                }
            }
        }

        //*******************************************
        // Exceptions
        //*******************************************

        private class DfqParserException : Exception {
            public DfqParserException(ParserContext context, Exception cause) : base(Message(context, cause), cause) {
            }

            internal static string Message(ParserContext context, Exception cause) {
                string message = "Failed to parse DFQ file. Error at line: " + context.CurrentLine;

                if (cause != null && cause.Message != null) {
                    message += " Cause: " + cause.Message;
                }

                return message;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unused") private static class UnknownKKeyException extends Exception
        private class UnknownKKeyException : Exception {
            private readonly KKey _key;

            public UnknownKKeyException(KKey key) : base() {
                this._key = key;
            }

            public virtual KKey Key {
                get {
                    return _key;
                }
            }

        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unused") private static class ValueConversionException extends Exception
        private class ValueConversionException : Exception {
            internal readonly string ValueRenamed;
            internal readonly KKey KeyRenamed;
            //JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
            //ORIGINAL LINE: private final cz.diribet.aqdef.convert.IKKeyValueConverter<?> converter;
            internal readonly IKKeyValueConverter  ConverterRenamed;

            public ValueConversionException(string value, KKey key, IKKeyValueConverter converter, Exception cause) : base(value,cause){

                this.ValueRenamed = value;
                this.KeyRenamed = key;
                this.ConverterRenamed = converter;
            }

            public virtual string Value {
                get {
                    return ValueRenamed;
                }
            }

            public virtual KKey Key {
                get {
                    return KeyRenamed;
                }
            }

            //JAVA TO C# CONVERTER WARNING: Java wildcard generics have no direct equivalent in .NET:
            //ORIGINAL LINE: public cz.diribet.aqdef.convert.IKKeyValueConverter<?> getConverter()
            public virtual IKKeyValueConverter Converter {
                get {
                    return ConverterRenamed;
                }
            }

        }
    }


}
