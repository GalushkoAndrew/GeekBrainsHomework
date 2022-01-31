using System;

namespace GeekBrains.Learn.Core.DTO.Base
{
    /// <summary>
    /// Base metric class
    /// </summary>
    public class MetricDto : IMetricDto
    {
        /// <inheritdoc/>
        public int Value { get; set; }

        /// <inheritdoc/>
        public DateTime Date { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }
    }
}
