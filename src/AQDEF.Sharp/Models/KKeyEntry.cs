using System.Text.RegularExpressions;
using AQDEF.Sharp;

namespace AQDEF.Models {
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
            int intIndex;
            if (int.TryParse(index, out intIndex)) {
                Index = intIndex;
            } else {
               // throw new AqdefValidityException($"Characteristic with index {index} was not found. Can't parse value.");
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

    /// <summary>
    /// K00XX/CharacteristicNo/ValueNo/PartNo/TrialNo/Operator/Reference
    /// </summary>
    public class ValueEntry : KKeyEntry {
        public ValueEntry(KKey key) : base(key) {
            this.PartNo = 1;
        }

        public ValueEntry(KKey key, int index, string value) : base(key, index, value) {
            this.PartNo = 1;
        }

        public ValueEntry(KKey key, string index, string value) : base(key, index, value) {
            this.PartNo = 1;
        }

        public int CharacteristicNo {
            get { return Index; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ValueNo { get; set; }

        /// <summary>
        /// 部件序号
        /// </summary>
        public int PartNo { get; set; }

        /// <summary>
        /// TrialNo
        /// </summary>
        public int TrialNo { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Reference/RefNo
        /// </summary>
        public int RefNo { get; set; }

      
    }

    /// <summary>
    /// 
    /// </summary>
    public class ValueEnties : BaseEnties {
        #region Overrides of BaseEnties

        /// <summary>
        /// entry Level
        /// </summary>
        public override KKeyLevel Level => KKeyLevel.VALUE;

        #endregion

        public ValueEnties(int index) : base(index) {
        }

        public ValueEnties(IKKeyEntry entry) : base(entry) {
        }
    }
}