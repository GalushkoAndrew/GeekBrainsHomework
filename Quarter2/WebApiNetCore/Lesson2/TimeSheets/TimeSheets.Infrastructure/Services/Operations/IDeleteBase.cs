using GeekBrains.Learn.TimeSheets.Domain.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations
{
    /// <summary>
    /// Базовый интерфейс операции удаления сущности в менеджере
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IDeleteBase<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">entity id</param>
        /// <param name="validationService">validation service</param>
        IOperationResult Delete(
            int id,
            IValidationService<TEntity> validationService);
    }
}
