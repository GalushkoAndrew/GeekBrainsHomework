﻿using System;

namespace GeekBrains.Learn.Core.Infrastructure.Manager
{
    /// <summary>
    /// Network metric manager
    /// </summary>
    public class NetworkManager : INetworkManager
    {
        /// <inheritdoc/>
        public bool GetMetricsFromAgent(int agentId, DateTime fromTime, DateTime toTime)
        {
            return true;
        }
    }
}
