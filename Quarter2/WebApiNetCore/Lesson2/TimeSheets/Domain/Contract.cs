using System;
using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Contract : Entity
    {
        /// <summary>
        /// Contract name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Consumer Id
        /// </summary>
        public int ConsumerId { get; set; }

        /// <summary>
        /// Consumer
        /// </summary>
        public virtual Consumer Consumer { get; set; }

        /// <summary>
        /// Contract's date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Approval mark
        /// </summary>
        public int IsApproved { get; set; }

        /// <summary>
        /// Specification
        /// </summary>
        public virtual ICollection<ContractWorkType> Rows { get; set; }
    }
}
