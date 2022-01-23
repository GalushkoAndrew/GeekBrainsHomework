using System;

namespace GeekBrains.Learn.Core.DAO.Model.Base
{
    /// <summary>
    /// Interface Metric entity
    /// </summary>
    public interface IMetric
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
