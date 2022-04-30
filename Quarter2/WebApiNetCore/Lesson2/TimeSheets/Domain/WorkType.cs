using GeekBrains.Learn.TimeSheets.Domain.Base;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// Тип работ
    /// </summary>
    public class WorkType : Entity
    {
        /// <summary>
        /// Work type name
        /// </summary>
        public string Name { get; set; }
    }
}
