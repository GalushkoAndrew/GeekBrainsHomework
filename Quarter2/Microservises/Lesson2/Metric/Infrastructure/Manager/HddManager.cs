using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Hdd metric manager
    /// </summary>
    public class HddManager : IHddManager
    {
        /// <inheritdoc/>
        public bool GetMetricsFromAgent(DateTime fromTime, DateTime toTime)
        {
            return true;
        }
    }
}
