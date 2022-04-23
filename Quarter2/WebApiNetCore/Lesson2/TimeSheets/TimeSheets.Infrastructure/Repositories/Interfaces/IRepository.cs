using System.Collections.Generic;
using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="TEntity"> <see cref="IEntity"/></typeparam>
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Returns entity by id
        /// </summary>
        /// <param name="id">id</param>
        TEntity GetById(int id);

        /// <summary>
        /// Returns entities list using pagination
        /// </summary>
        /// <param name="skip">how much records to skip</param>
        /// <param name="take">records count to return</param>
        IReadOnlyCollection<TEntity> GetPageList(int skip, int take);

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">entity</param>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">entity</param>
        int Update(TEntity entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        int Delete(TEntity entity);
    }
}
