using GeekBrains.Learn.Domain.Base;

namespace GeekBrains.Learn.Domain
{
    /// <summary>
    /// Invoice, body
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
