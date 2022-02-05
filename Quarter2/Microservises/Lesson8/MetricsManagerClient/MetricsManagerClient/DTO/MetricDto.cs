using System;

namespace MetricsManagerClient.DTO
{
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
