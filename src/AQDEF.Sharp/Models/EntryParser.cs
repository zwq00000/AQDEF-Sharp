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
        /// <summary>
        /// These keys does not contain any information and we can safely ignore them.
        /// </summary>
        private static readonly string[] IGNORED_KEYS = new string[] { "K0100", "K100", "K0101", "K101" };

        static readonly Regex KKeyRegex = new Regex(@"(?<KKey>K\d{4})(/(?<Index>\d+))?(/\d+)*(\s+(?<Value>.*))?", RegexOptions.Compiled | RegexOptions.Singleline);
        static readonly Regex ValueEntryRegex = new Regex(@"(K\D{4})(/(?<Index>\d+))?(/(?<ValueNo>\d+))?(/(?<PartNo>\d+))?(/(?<TrialNo>\d+))?(/(?<RefNo>\d+))?", RegexOptions.Compiled | RegexOptions.Singleline);
        
        private static bool IsKKeyLine(string line) {
            return KKeyRegex.IsMatch(line);
            //return line.StartsWith("K", StringComparison.Ordinal);
        }

        private static bool IsBinaryDataLine(string line) {
            return line.IndexOf(AqdefConstants.MeasuredValuesDataSeparator) >= 0;
        }

        /// <summary>
        /// K00XX/CharacteristicNo/ValueNo/PartNo/TrialNo/Operator/Reference
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private static ValueEntry UpdateValueEntry(ValueEntry entry, string line) {
            var match = ValueEntryRegex.Match(line);
            if (match.Success) {
                var indexcharacteristicNo = match.Result("${Index}");
                var valueNo = match.Result("${ValueNo}");
                var partNo = match.Result("${PartNo}");
                var trialNo = match.Result("${TrialNo}");
                var refNo = match.Result("${RefNo}");
                int value = 0;
                if (int.TryParse(valueNo, out value)) {
                    entry.ValueNo = value;
                }
                if (int.TryParse(partNo, out value)) {
                    entry.PartNo = value;
                }
                if (int.TryParse(trialNo, out value)) {
                    entry.TrialNo = value;
                }
                if (int.TryParse(refNo, out value)) {
                    entry.RefNo = value;
                }
            }

            return entry;
        }

        public static bool ParseKKeyLine(string line, out IKKeyEntry entry) {
            Match match = KKeyRegex.Match(line);
            if (match.Success) {
                var keyStr = match.Result("${KKey}");
                var index = match.Result("${Index}");
                var value = match.Result("${Value}");
                if (!IsIgnoredKey(keyStr)) {

                    var kkey = KKey.Of(keyStr);
                    if (kkey.IsValueLevel) {
                        entry = new ValueEntry(kkey,index,value);
                        UpdateValueEntry((ValueEntry) entry, line);
                    } else {
                        entry = new KKeyEntry(kkey, index, value);
                    }
#if DEBUG
                    var kkeyEntry = (KKeyEntry) entry;
                    kkeyEntry.RawLine = line;
#endif
                    return true;
                }
            }
            entry = null;
            return false;
        }

        private static bool IsIgnoredKey(string key) {
            return IGNORED_KEYS.Contains(key);
        }

        /// <summary>
        /// 解析数据行
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static IEnumerable<BinaryData> ParseBinaryDataLine(string line) {
            string[] characteristicPortions = line.Split(AqdefConstants.MeasuredValuesCharacteristicSeparator);
            foreach (string characteristicPortion in characteristicPortions) {
                string[] dataPortions = characteristicPortion.Split(AqdefConstants.MeasuredValuesDataSeparator);
                yield return new BinaryData(dataPortions);
            }
        }

        public static void ParseLine(string line) {
            IKKeyEntry entry;
            ParseKKeyLine(line, out entry);
        }

        public static IEnumerable<IKKeyEntry> Parse(string content) {
            using (var reader = new StringReader(content)) {
                return ParseKKeyLines(reader).ToArray<IKKeyEntry>();
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
                } else if (IsBinaryDataLine(line)) {
                    var values = ParseBinaryDataLine(line);
                    foreach (var data in values) {
                        Debug.WriteLine(data);
                    }
                }
            }
        }

        private class ModelBuilder {
            PartEnties _part = null;
            CharacteristicEnties _characteristicEnties = null;
            private readonly AqdefModel _model;

            public ModelBuilder(AqdefModel model) {
                this._model = model;
            }

            public void Append(IKKeyEntry entry) {
                switch (entry.Key.Level) {
                    case KKeyLevel.VALUE:
                        if (_characteristicEnties == null) {
                            _model.Add(entry);
                        } else {
                            var valueEntry = entry as ValueEntry;
                            var characteristicEnties = _model.GetCharacteristicEntries(valueEntry.PartNo,valueEntry.CharacteristicNo);
                            characteristicEnties?.Add(entry);
                            //_characteristicEnties.Add(entry);
                        }
                        break;
                    case KKeyLevel.Part:
                        //part.Add(entry);
                        _model.Parts.Add(entry);
                        if (entry.Index != 0) {
                            _part = _model.Parts[entry.Index];
                        }
                        break;
                    case KKeyLevel.Characteristic:
                        _part.Characteristics.Add(entry);
                        if (entry.Index != 0) {
                            _characteristicEnties = _part.Characteristics[entry.Index];
                        }
                        break;
                }
            }
        }
    }
}