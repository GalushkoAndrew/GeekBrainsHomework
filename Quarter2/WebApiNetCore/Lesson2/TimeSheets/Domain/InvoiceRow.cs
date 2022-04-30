using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Акт выполненных работ. Спецификация
    /// </summary>
    public class InvoiceRow : Entity
    {
        /// <summary>
        /// Invoice Id
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Invoice
        /// </summary>
        public virtual Invoice Invoice { get; set; }

        /// <summary>
        /// Work Id
        /// </summary>
        public int WorkId { get; set; }

        /// <summary>
        /// Work
        /// </summary>
        public virtual Work Work { get; set; }
    }
}
