using System;
using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Акт выполненных работ. Заголовок
    /// </summary>
    public class Invoice : Entity
    {
        /// <summary>
        /// Invoice's date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Specification
        /// </summary>
        public virtual ICollection<InvoiceRow> Rows { get; set; }
    }
}
