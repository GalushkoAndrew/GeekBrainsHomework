namespace GeekBrains.Learn.TimeSheets.Infrastructure.Services.Validation.Base
{
    /// <summary>
    /// validation problem result interface
    /// </summary>
    public interface IOperationFailure
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Problem description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Problem code
        /// </summary>
        public string Code { get; set; }
    }
}
