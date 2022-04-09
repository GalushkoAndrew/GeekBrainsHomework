namespace GeekBrains.Learn.Domain.Base
{
    /// <summary>
    /// Base class for entity. Include field Id
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }
    }
}
