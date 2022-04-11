using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Repositories
{
    /// <summary>
    /// Employee Repository
    /// </summary>
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        /// <inheritdoc/>
        public void Create(Employee entity)
        {
            return;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            return;
        }

        /// <inheritdoc/>
        public Employee GetById(int id)
        {
            return new Employee
            {
                Id = 1,
                Name = "Иванов"
            };
        }

        /// <inheritdoc/>
        public ICollection<Employee> GetByTerm(string term)
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Иванов"
                }
            };
        }

        /// <inheritdoc/>
        public ICollection<Employee> GetPageList(int skip, int take)
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Иванов"
                }
            };
        }

        /// <inheritdoc/>
        public void Update(Employee entity)
        {
            return;
        }
    }
}
