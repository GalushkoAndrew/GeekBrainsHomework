using System.Collections.Generic;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base
{
    /// <summary>
    /// Validation service interface
    /// </summary>
    /// <typeparam name="TEntity">checked entity</typeparam>
    public interface IValidationService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="item">validated entity</param>
        IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item);
    }
}
