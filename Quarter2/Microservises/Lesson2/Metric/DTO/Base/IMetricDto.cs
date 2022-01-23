using System;

namespace GeekBrains.Learn.Core.DTO.Base
{
    /// <summary>
    /// interface metric dto
    /// </summary>
    public interface IMetricDto
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Metric value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Metric date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
