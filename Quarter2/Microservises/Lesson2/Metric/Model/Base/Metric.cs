using System;
using GeekBrains.Learn.Core.DAO.Model.Base;

namespace GeekBrains.Learn.Core.DAO.Model.Models
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
