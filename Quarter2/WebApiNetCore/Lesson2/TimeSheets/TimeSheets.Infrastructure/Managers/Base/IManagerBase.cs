using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base
{
    /// <summary>
    /// Base manager interface
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TDto">Dto</typeparam>
    public interface IManagerBase<TEntity, TDto>
    {
        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="dto">dto</param>
        IOperationResult Create(TDto dto);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">entity id</param>
        IOperationResult Delete(int id);

        /// <summary>
        /// Returns dto by id
        /// </summary>
        /// <param name="id">id</param>
        TDto GetById(int id);

        /// <summary>
        /// Returns dto list using pagination
        /// </summary>
        /// <param name="skip">how much records to skip</param>
        /// <param name="take">records count to return</param>
        IReadOnlyCollection<TDto> GetPageList(int skip, int take);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="dto">dto</param>
        IOperationResult Update(TDto dto);
    }
}
