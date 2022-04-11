using System;
using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Invoice, header
    /// </summary>
    public class Invoice : Entity
    {
        /// <summary>
        /// Invoice's date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
