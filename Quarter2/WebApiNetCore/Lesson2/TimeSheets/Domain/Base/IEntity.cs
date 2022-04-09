namespace GeekBrains.Learn.Domain.Base
{
    /// <summary>
    /// Base interface for entity. Include field Id
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        int Id { get; set; }
    }
}
