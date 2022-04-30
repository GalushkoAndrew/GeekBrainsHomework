using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Исполнитель
    /// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// Employee name
        /// </summary>
        public string Name { get; set; }
    }
}
