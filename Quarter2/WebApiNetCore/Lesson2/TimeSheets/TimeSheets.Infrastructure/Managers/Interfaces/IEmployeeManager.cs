using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Dto;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Interfaces
{
    /// <summary>
    /// Employee manager interface
    /// </summary>
    public interface IEmployeeManager
    {
        /// <summary>
        /// Returns dto by id
        /// </summary>
        /// <param name="id">id</param>
        EmployeeDto GetById(int id);

        /// <summary>
        /// Returns dto list filtered by part of name
        /// </summary>
        /// <param name="term">part of name</param>
        IReadOnlyCollection<EmployeeDto> GetByTerm(string term);

        /// <summary>
        /// Returns dto list using pagination
        /// </summary>
        /// <param name="skip">how much records to skip</param>
        /// <param name="take">records count to return</param>
        IReadOnlyCollection<EmployeeDto> GetPageList(int skip, int take);

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">entity</param>
        void Create(EmployeeDto entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">entity</param>
        void Update(EmployeeDto entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">entity id</param>
        void Delete(int id);
    }
}
