using System;
using GeekBrains.Learn.Domain.Base;

namespace GeekBrains.Learn.Domain
{
    /// <summary>
    /// Work
    /// </summary>
    public class Work : Entity
    {
        /// <summary>
        /// ContractWorkType Id
        /// </summary>
        public int ContractWorkTypeId { get; set; }

        /// <summary>
        /// ContractWorkType
        /// </summary>
        public virtual ContractWorkType ContractWorkType { get; set; }

        /// <summary>
        /// Employee Id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Work description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date begin
        /// </summary>
        public DateTime DateBegin { get; set; }

        /// <summary>
        /// Date end
        /// </summary>
        public DateTime DateEnd { get; set; }
    }
}
