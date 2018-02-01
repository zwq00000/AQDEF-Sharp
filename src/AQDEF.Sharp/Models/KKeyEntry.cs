using AQDEF.Sharp;

namespace AQDEF.Models {
    public class KKeyEntry : IKKeyEntry {
        private const int DefaultIndex = 1;

        public KKeyEntry(KKey key) {
            this.Key = key;
            this.Index = DefaultIndex;
        }

        public KKeyEntry(KKey key, int index, string value):this(key) {
            this.Key = key;
            this.Index = index;
            this.Text = value;
        }

        public KKeyEntry(KKey key, string index, string value):this(key) {
            this.Text = value;
            int intIndex;
            if (int.TryParse(index, out intIndex)) {
                Index = intIndex;
            }
        }

        

        #region Implementation of IKKeyEntry

        /// <summary>
        /// Key <see cref="KKey"/>
        /// </summary>
        public KKey Key { get; }

        /// <summary>
        /// Ë÷Òý
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Öµ
        /// </summary>
        public string Text { get; set; }

        public void SetValue(object value) {
            Text = Key.Converter.ToString();
        }

        public object Value {
            get { return Key.Converter.Convert(Text); }
        }

        #endregion
    }
}