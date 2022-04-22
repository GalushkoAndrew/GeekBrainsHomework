using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Domain;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Employee repository interface
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Returns entities list filtered by part of name
        /// </summary>
        /// <param name="term">part of name</param>
        ICollection<Employee> GetByTerm(string term);
    }
}
