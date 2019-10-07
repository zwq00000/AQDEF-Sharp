using AQDEF.Sharp.Models;
using System;
using System.IO;
using System.Linq;

namespace AQDEF.Sharp {

    /// <summary>
    /// Writes {@link AqdefObjectModel} to AQDFQ text structure.
    /// <p> You can call {
    /// @link #writeTo(Writer)} to write DFQ content to a given writer
    ///  or {@link #getData()} to get DFQ content as a String. DFQ content is created
    ///  lazily when one of these methods is called.
    /// </p >
    /// </summary>
    public static class AqdefWriter {

        /// <summary>
        /// Creates AQDFQ structure and returns it as a String
        /// </summary>
        /// <param name="aqdefObjectModel"></param>
        /// <returns></returns>
        public static String WriteToString([NotNull] AqdefObjectModel aqdefObjectModel) {
            if (aqdefObjectModel == null) {
                throw new ArgumentNullException(nameof(aqdefObjectModel));
            }

            using (StringWriter fileContent = new StringWriter()) {

                WriteTo(aqdefObjectModel, fileContent);

                return fileContent.ToString();
            }
        }

        /**
         * Creates AQDEF structure and writes it to a given <code>writer</code>
         *
         * @param aqdefObjectModel
         *            model to be written, must not be {@code null}
         * @param writer
         *            writer to write model to, must not be {@code null}
         * @throws IOException
         *             thrown when some I/O error occur
         */
        public static void WriteTo(AqdefObjectModel aqdefObjectModel, TextWriter writer) {
            if (aqdefObjectModel == null) {
                throw new ArgumentNullException(nameof(aqdefObjectModel));
            }

            if (writer == null) {
                throw new ArgumentNullException(nameof(writer));
            }

            WriteEntries(aqdefObjectModel, writer);
        }

        private static void WriteEntries(AqdefObjectModel aqdefObjectModel, TextWriter writer) {
            aqdefObjectModel.Normalize();

            // AQDEF structure always starts with the total number of characteristics
            Write("K0100", null, aqdefObjectModel.CharacteristicCount.ToString(), writer);

            aqdefObjectModel.ForEachPart(part => {
                Write(part, writer);

                aqdefObjectModel.ForEachCharacteristic(part, (characteristic) => {
                    Write(characteristic, writer);

                    aqdefObjectModel.ForEachValue(part, characteristic, (value) => {
                        Write(value, writer);
                    });
                });

                aqdefObjectModel.ForEachGroup(part, (group) => {
                    Write(group, writer);
                });
            });

            aqdefObjectModel.Hierarchy.ForEachNodeDefinition(nodeDefinition => {
                Write(nodeDefinition, writer);
            });

            aqdefObjectModel.Hierarchy.ForEachNodeBinding(nodeBinding => {
                Write(nodeBinding, writer);
            });
        }

        private static void Write(PartEntries part, TextWriter writer) {
            part.Values
                .OrderBy(e => e.Key)
                .ForEach(partEntry => Write(partEntry, writer));
        }

        private static void Write(PartEntry entry, TextWriter writer) {
            KKey kKey = entry.Key;

            Write(kKey.Key, entry.Index.Index, ConvertValueOfKKey(kKey, entry.Value), writer);
        }

        private static void Write(CharacteristicEntries characteristic, TextWriter writer) {
            characteristic.Values
                .OrderBy(e => e.Key)
                          .ForEach(characteristicEntry => Write(characteristicEntry, writer));
        }

        private static void Write(CharacteristicEntry entry, TextWriter writer) {
            KKey kKey = entry.Key;

            Write(kKey.Key, entry.Index.Index, ConvertValueOfKKey(kKey, entry.Value), writer);
        }

        private static void Write(GroupEntries group, TextWriter writer) {
            group.Values
                .OrderBy(e => e.Key)
                 .ForEach(characteristicEntry => Write(characteristicEntry, writer));
        }

        private static void Write(GroupEntry entry, TextWriter writer) {
            KKey kKey = entry.Key;

            Write(kKey.Key, entry.Index.Index, ConvertValueOfKKey(kKey, entry.Value), writer);
        }

        private static void Write(ValueEntries value, TextWriter writer) {
            value.Values.OrderBy(e => e.Key)
                 .ForEach(valueEntry => Write(valueEntry, writer));
        }

        private static void Write(ValueEntry entry, TextWriter writer) {
            KKey kKey = entry.Key;
            int? characteristicIndex = entry.Index.CharacteristicIndex.Index;
            String value = ConvertValueOfKKey(kKey, entry.Value);

            Write(kKey.Key, characteristicIndex, value, writer);
        }

        private static void Write(AqdefHierarchy.HierarchyEntry entry, TextWriter writer) {
            KKey kKey = entry.Key;

            Write(kKey.Key, entry.Index.Index, ConvertValueOfKKey(kKey, entry.Value), writer);
        }

        private static void Write(String key, int? index, String value, TextWriter writer) {
            writer.Write(key);

            if (index != null) {
                writer.Write("/");
                writer.Write(index);
            }

            writer.Write(AqdefConstants.ValuesSeparator);
            writer.Write(defaultString(value, String.Empty));
            writer.Write(AqdefConstants.LineSeparator);

        }

        private static string ConvertValueOfKKey(KKey kKey, Object value) {
            String result;

            try {
                var converter = kKey.Converter;
                if (converter == null) {
                    throw new NullReferenceException($"Can't find converter for k-key {kKey}");
                }

                result = converter.ToString(value);

            } catch (Exception e) {
                throw new NotSupportedException($"Failed to convert value ({value}) of k-key {kKey} to string", e);
            }

            result = result?.Trim();

            return result;
        }

        private static string defaultString(string value, string defalutValue) {
            if (string.IsNullOrEmpty(value)) {
                return defalutValue;
            }

            return value;

        }

    }
}
