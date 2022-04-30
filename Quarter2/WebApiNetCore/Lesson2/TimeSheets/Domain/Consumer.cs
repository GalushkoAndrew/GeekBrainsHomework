using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Заказчик
    /// </summary>
    public class Consumer : Entity
    {
        /// <summary>
        /// Consumer name
        /// </summary>
        public string Name { get; set; }
    }
}
