using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AQDEF.Sharp;

namespace AQDEF.Models {

    /// <summary>
    /// KKey AQDEF 文档解析器
    /// </summary>
    public static class EntryParser {
        static readonly Regex KKeyRegex = new Regex(@"(?<KKey>K\d{4})(/(?<Index>\d+))?(\s+(?<Value>.*))?", RegexOptions.Compiled | RegexOptions.Singleline);

        private static bool IsKKeyLine(string line) {
            return KKeyRegex.IsMatch(line);
            //return line.StartsWith("K", StringComparison.Ordinal);
        }

        private static bool IsBinaryDataLine(string line) {
            return line.IndexOf(AqdefConstants.MEASURED_VALUES_DATA_SEPARATOR) >= 0;
        }

        public static bool ParseKKeyLine(string line, out IKKeyEntry entry) {
            Match match = KKeyRegex.Match(line);
            if (match.Success) {
                var key = match.Result("${KKey}");
                var index = match.Result("${Index}");
                var value = match.Result("${Value}");
                entry = new KKeyEntry(KKey.Of(key), index, value);
                return true;
            } else {
                entry = null;
                return false;
            }
        }

        /// <summary>
        /// 解析数据行
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static IEnumerable<BinaryData> ParseBinaryDataLine(string line) {
            string[] characteristicPortions = line.Split(AqdefConstants.MEASURED_VALUES_CHARACTERISTIC_SEPARATOR);
            foreach (string characteristicPortion in characteristicPortions) {
                string[] dataPortions = characteristicPortion.Split(AqdefConstants.MEASURED_VALUES_DATA_SEPARATOR);
                yield return new BinaryData(dataPortions);
            }
        }

        public static void ParseLine(string line) {
            IKKeyEntry entry;
            ParseKKeyLine(line, out entry);
        }

        public static IEnumerable<IKKeyEntry> Parse(string content) {
            using (var reader = new StringReader(content)) {
                return Enumerable.ToArray<IKKeyEntry>(ParseKKeyLines(reader));
            }
        }

        private static IEnumerable<IKKeyEntry> ParseKKeyLines(TextReader reader) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(line)) {
                    continue;
                }
                IKKeyEntry entry;
                if (ParseKKeyLine(line, out entry)) {
                    yield return entry;
                }
            }
        }

        private static IEnumerable<BinaryData[]> ParseBinaryDataLines(TextReader reader) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(line)) {
                    continue;
                }
                if (IsBinaryDataLine(line)) {
                    yield return ParseBinaryDataLine(line).ToArray();
                }
            }
        }

        public static void Parse(this AqdefModel model, TextReader reader) {
            
            var builder = new ModelBuilder(model);
            string line;
            while ((line = reader.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(line)) {
                    continue;
                }
                if (IsKKeyLine(line)) {
                    IKKeyEntry kKeyEntry;
                    if (ParseKKeyLine(line, out kKeyEntry)) {
                        builder.Append(kKeyEntry);
                    }
                }else if (IsBinaryDataLine(line)) {
                    var values = ParseBinaryDataLine(line);
                    foreach (var data in values) {
                        Debug.WriteLine(data);
                    }
                }
            }
        }

        private class ModelBuilder {
            PartEntry _part = null;
            CharacteristicEntry _characteristicEntry = null;
            private readonly AqdefModel _model;

            public ModelBuilder(AqdefModel model) {
                this._model = model;
            }

            public void Append(IKKeyEntry entry) {
                switch (entry.Key.Level) {
                    case KKey.KKeyLevel.VALUE:
                        if (_characteristicEntry == null) {
                            _model.Add(entry);
                        } else {
                            _characteristicEntry.Add(entry);
                        }
                        break;
                    case KKey.KKeyLevel.PART:
                        //part.Add(entry);
                        _model.Parts.Add(entry);
                        if (entry.Index != 0) {
                            _part = _model.Parts[entry.Index];
                        }
                        break;
                    case KKey.KKeyLevel.CHARACTERISTIC:
                        _part.Characteristics.Add(entry);
                        if (entry.Index != 0) {
                            _characteristicEntry = _part.Characteristics[entry.Index];
                        }
                        break;
                }
            }
        }
    }
}