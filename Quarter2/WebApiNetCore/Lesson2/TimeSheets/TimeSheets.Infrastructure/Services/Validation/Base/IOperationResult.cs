using System.Collections.Generic;

namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base
{
    /// <summary>
    /// operation result interface
    /// </summary>
    public interface IOperationResult
    {
        /// <summary>
        /// problem list
        /// </summary>
        IReadOnlyList<IOperationFailure> Failures { get; }

        /// <summary>
        /// Mark true if operation is success
        /// </summary>
        bool IsSuccess { get; }
    }
}
