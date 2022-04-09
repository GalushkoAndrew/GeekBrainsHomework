using System;
using GeekBrains.Learn.Domain.Base;

namespace GeekBrains.Learn.Domain
{
    /// <summary>
    /// Contract's header
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
    }
}
