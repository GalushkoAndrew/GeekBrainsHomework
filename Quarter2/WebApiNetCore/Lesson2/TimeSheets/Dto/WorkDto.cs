using System;
using GeekBrains.Learn.TimeSheets.Dto.Base;

namespace GeekBrains.Learn.TimeSheets.Dto
{
    /// <summary>
    /// Work
    /// </summary>
    public class WorkDto : IdentifierDto
    {
        /// <summary>
        /// ContractWorkType
        /// </summary>
        public virtual ContractWorkTypeDto ContractWorkType { get; set; }

        /// <summary>
        /// Date begin
        /// </summary>
        public DateTime DateBegin { get; set; }

        /// <summary>
        /// Date end
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public virtual EmployeeDto Employee { get; set; }

        /// <summary>
        /// Work description
        /// </summary>
        public string Description { get; set; }
    }
}
