namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base
{
    /// <summary>
    /// validation problem result
    /// </summary>
    public class OperationFailure : IOperationFailure
    {
        /// <inheritdoc/>
        public string PropertyName { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }

        /// <inheritdoc/>
        public string Code { get; set; }
    }
}
