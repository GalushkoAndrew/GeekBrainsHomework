using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        /// <summary>
        /// Invoice initialize
        /// </summary>
        public void Create()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// Add sheets to invoice
        /// </summary>
        public void IncludeSheets(ICollection<InvoiceRow> sheets)
        {
            if (Rows == null) {
                Rows = new Collection<InvoiceRow>();
            }

            foreach (var sheet in sheets) {
                if (!Rows.Any(x => x.Id == sheet.Id)) {
                    Rows.Add(sheet);
                }
            }
        }
    }
}
