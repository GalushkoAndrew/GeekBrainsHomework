using System;
using System.Collections.Generic;
using GeekBrains.Learn.Dto.Base;

namespace GeekBrains.Learn.Dto
{
    /// <summary>
    /// Contract
    /// </summary>
    public class ContractDto : IdentifierDto
    {
        /// <summary>
        /// Contract name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Consumer
        /// </summary>
        public virtual ConsumerDto Consumer { get; set; }

        /// <summary>
        /// Contract date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Approval mark
        /// </summary>
        public int IsApproved { get; set; }

        /// <summary>
        /// Work types with price
        /// </summary>
        public List<ContractWorkTypeDto> Rows { get; set; }
    }
}
