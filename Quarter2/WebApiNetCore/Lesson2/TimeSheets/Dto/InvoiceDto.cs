using System;
using System.Collections.Generic;
using GeekBrains.Learn.Dto.Base;

namespace GeekBrains.Learn.Dto
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
        public List<InvoiceRowDto> Rows { get; set; }
    }
}
