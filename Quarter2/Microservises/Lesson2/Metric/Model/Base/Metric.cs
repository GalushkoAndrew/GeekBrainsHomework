using System;

namespace GeekBrains.Learn.Core.DAO.Model.Base
{
    /// <summary>
    /// Base metric class
    /// </summary>
    public class Metric : IMetric
    {
        /// <inheritdoc/>
        public int Value { get; set; }

        /// <inheritdoc/>
        public DateTime Date { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }
    }
}
