using System;
using GeekBrains.Learn.Domain.Base;

namespace GeekBrains.Learn.Domain
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
