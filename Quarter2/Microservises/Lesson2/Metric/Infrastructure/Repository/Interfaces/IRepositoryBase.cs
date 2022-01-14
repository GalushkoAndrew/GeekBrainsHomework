using GeekBrains.Learn.Core.DAO.Model.Base;

namespace GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public interface IRepositoryBase<T>
        where T : class, IHaveId
    {
        /// <summary>
        /// Create entity
        /// </summary>
        T Create(T entity);

        /// <summary>
        /// Get single entity
        /// </summary>
        T Get(int id);

        /// <summary>
        /// Update entity value
        /// </summary>
        T Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        void Delete(int id);
    }
}
