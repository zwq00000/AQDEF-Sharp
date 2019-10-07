namespace AQDEF.Sharp.Models {
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
        /// ²¿¼þÐòºÅ
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
}