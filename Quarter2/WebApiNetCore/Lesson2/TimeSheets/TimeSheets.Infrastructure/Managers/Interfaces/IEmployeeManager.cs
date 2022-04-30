using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces
{
    /// <summary>
    /// Employee manager interface
    /// </summary>
    public interface IEmployeeManager : IManagerBase<Employee, EmployeeDto>
    {
        /// <summary>
        /// Returns dto list filtered by part of name
        /// </summary>
        /// <param name="term">part of name</param>
        IReadOnlyCollection<EmployeeDto> GetByTerm(string term);
    }
}
