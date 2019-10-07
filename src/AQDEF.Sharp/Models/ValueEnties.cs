namespace AQDEF.Sharp.Models {
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