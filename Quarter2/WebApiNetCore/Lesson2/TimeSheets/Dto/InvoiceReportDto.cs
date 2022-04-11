using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.TimeSheets.Dto
{
    /// <summary>
    /// Invoice report
    /// </summary>
    public class InvoiceReportDto
    {
        /// <summary>
        /// Consumer name
        /// </summary>
        public string ConsumerName { get; set; }

        /// <summary>
        /// Invoice number
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Contract date
        /// </summary>
        public DateTime ContractDate { get; set; }

        /// <summary>
        /// Contract name
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// Total cost
        /// </summary>
        public int TotalCost { get; set; }

        /// <summary>
        /// Specification
        /// </summary>
        public List<InvoiceReportRowDto> Rows { get; set; }
    }
}
