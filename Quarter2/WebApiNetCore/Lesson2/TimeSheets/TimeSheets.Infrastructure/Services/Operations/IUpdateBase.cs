using GeekBrains.Learn.TimeSheets.Domain.Base;
using GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Operations
{
    /// <summary>
    /// Базовый интерфейс операции изменения сущности в менеджере
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TDto">Dto</typeparam>
    public interface IUpdateBase<TEntity, TDto>
        where TEntity : IEntity
        where TDto : class
    {
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="dto">dto</param>
        /// <param name="validationService">validation service</param>
        IOperationResult Update(
            TDto dto,
            IValidationService<TDto> validationService);
    }
}
