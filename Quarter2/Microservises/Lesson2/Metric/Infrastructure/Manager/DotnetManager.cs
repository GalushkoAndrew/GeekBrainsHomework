using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Dotnet metric manager
    /// </summary>
    public class DotnetManager : IDotnetManager
    {
        /// <inheritdoc/>
        public bool GetMetricsFromAgent(int agentId, DateTime fromTime, DateTime toTime)
        {
            return true;
        }
    }
}
