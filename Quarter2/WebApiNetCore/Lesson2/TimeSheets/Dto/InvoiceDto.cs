using System;
using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Dto.Base;

namespace GeekBrains.Learn.TimeSheets.Dto
{
    /// <summary>
    /// Invoice
    /// </summary>
    public class InvoiceDto : IdentifierDto
    {
        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Works
        /// </summary>
        public virtual List<InvoiceRowDto> Rows { get; set; }
    }
}
