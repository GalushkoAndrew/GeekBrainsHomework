using System.Collections.Generic;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base
{
    /// <summary>
    /// operation result
    /// </summary>
    public class OperationResult : IOperationResult
    {
        /// <inheritdoc/>
        public OperationResult(IReadOnlyList<IOperationFailure> failures)
        {
            Failures = failures ?? new List<IOperationFailure>();
            IsSuccess = Failures.Count <= 0;
        }

        /// <inheritdoc/>
        public IReadOnlyList<IOperationFailure> Failures { get; set; }

        /// <inheritdoc/>
        public bool IsSuccess { get; set; }
    }
}
