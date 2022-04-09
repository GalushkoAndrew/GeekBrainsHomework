using GeekBrains.Learn.Domain.Base;

namespace GeekBrains.Learn.Domain
{
    /// <summary>
    /// Contract's body
    /// Link with work type
    /// </summary>
    public class ContractWorkType : Entity
    {
        /// <summary>
        /// Contract Id
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// Contract
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// WorkType Id
        /// </summary>
        public int WorkTypeId { get; set; }

        /// <summary>
        /// WorkType
        /// </summary>
        public virtual WorkType WorkType { get; set; }

        /// <summary>
        /// Price per hour
        /// </summary>
        public int Price { get; set; }
    }
}
