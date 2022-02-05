using System;

namespace MetricsManagerClient.DTO
{
    public interface IMetricDto
    {
        /// <summary>
        /// Identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Metric value
        /// </summary>
        int Value { get; set; }

        /// <summary>
        /// Metric date
        /// </summary>
        DateTime Date { get; set; }
    }
}
