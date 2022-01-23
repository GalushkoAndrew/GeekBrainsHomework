namespace GeekBrains.Learn.Core.Infrastructure.Repository.Interfaces
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public interface IRepositoryBase<T>
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
        /// Update entity
        /// </summary>
        T Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        int Delete(int id);
    }
}
