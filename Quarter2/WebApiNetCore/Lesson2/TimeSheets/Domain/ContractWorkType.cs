using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Прайс на виды работ по заказу. Единицы: тугриков в час.
    /// </summary>
    public class ContractWorkType : Entity
    {
        /// <summary>
        /// Contract Id
        /// </summary>
        public int ContractId { get; set; }

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
