using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base
{
    /// <summary>
    /// Base validation service
    /// </summary>
    /// <typeparam name="TEntity">checked entity</typeparam>
    public abstract class FluentValidationService<TEntity> : AbstractValidator<TEntity>, IValidationService<TEntity>
        where TEntity : class
    {
        /// <inheritdoc/>
        public IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item)
        {
            ValidationResult result = Validate(item);

            if (result is null || result.Errors.Count == 0)
            {
                return ArraySegment<IOperationFailure>.Empty;
            }

            List<IOperationFailure> failures = new List<IOperationFailure>(result.Errors.Count);

            foreach (ValidationFailure error in result.Errors)
            {
                failures.Add(new OperationFailure
                {
                    PropertyName = error.PropertyName,
                    Description = error.ErrorMessage,
                    Code = error.ErrorCode
                });
            }

            return failures;
        }
    }
}
