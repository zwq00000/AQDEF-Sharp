namespace AQDEF.Sharp.Models {
    public class KKeyEntry : IKKeyEntry {
        private const int DefaultIndex = 1;

        public KKeyEntry(KKey key) {
            this.Key = key;
            this.Index = DefaultIndex;
        }

        public KKeyEntry(KKey key, int index, string value) : this(key) {
            this.Key = key;
            this.Index = index;
            this.Text = value;
        }

        public KKeyEntry(KKey key, string index, string value) : this(key) {
            this.Text = value;
            if (int.TryParse(index, out var intIndex)) {
                Index = intIndex;
            } else {
               throw new AqdefValidityException($"Characteristic with index {index} was not found. Can't parse value.");
            }
        }



        #region Implementation of IKKeyEntry

        /// <summary>
        /// Key <see cref="KKey"/>
        /// </summary>
        public KKey Key { get; }

        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Text { get; set; }

        public void SetValue(object value) {
            Text = Key.Converter.ToString();
        }

        public object Value {
            get { return Key.Converter.Convert(Text); }
        }

        #endregion

        /// <summary>
        /// 原始数据行
        /// </summary>
        internal string RawLine { get; set; }
    }
}