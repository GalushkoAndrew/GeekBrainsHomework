using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Domain;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Employee repository interface
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Returns entity by id
        /// </summary>
        /// <param name="id">id</param>
        Employee GetById(int id);

        /// <summary>
        /// Returns entities list filtered by part of name
        /// </summary>
        /// <param name="term">part of name</param>
        ICollection<Employee> GetByTerm(string term);

        /// <summary>
        /// Returns entities list using pagination
        /// </summary>
        /// <param name="skip">how much records to skip</param>
        /// <param name="take">records count to return</param>
        ICollection<Employee> GetPageList(int skip, int take);

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">entity</param>
        void Create(Employee entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">entity</param>
        void Update(Employee entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">entity id</param>
        void Delete(int id);
    }
}
