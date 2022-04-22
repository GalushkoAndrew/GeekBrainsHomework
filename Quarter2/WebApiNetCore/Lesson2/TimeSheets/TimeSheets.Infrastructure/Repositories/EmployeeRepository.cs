using System.Collections.Generic;
using System.Linq;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Repositories
{
    /// <summary>
    /// Employee Repository
    /// </summary>
    public sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        /// <inheritdoc/>
        public EmployeeRepository(TimeSheetsDbContext dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc/>
        public ICollection<Employee> GetByTerm(string term)
        {
            return _dbContext.Employees.Where(x => x.Name.Contains(term)).ToList();
        }
    }
}
