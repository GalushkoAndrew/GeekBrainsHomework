﻿using System;
using GeekBrains.Learn.Core.DAO.Model.Models;
using GeekBrains.Learn.Core.DTO;
using GeekBrains.Learn.Core.MetricsAgent.Controller.Controllers;
using Moq;
using Xunit;

namespace GeekBrains.Learn.Core.MetricsAgent.ControllerTests
{
    /// <inheritdoc/>
    public class NetworkMetricControllerTests : MetricTestsBase<NetworkMetric, NetworkMetricDto, NetworkMetricController>
    {
        private readonly NetworkMetricController _controller;

        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricControllerTests() : base()
        {
            _controller = new NetworkMetricController(Manager.Object, Logger.Object);
        }

        /// <summary>
        /// Unit test
        /// </summary>
        [Fact]
        public void Test()
        {
            Manager.Setup(x => x.GetMetricsFromAgent(It.IsAny<DateTime>(), It.IsAny<DateTime>()));
            _controller.GetMetricsFromAgent(It.IsAny<DateTime>(), It.IsAny<DateTime>());
            VerifyLogger();
            Manager.VerifyAll();
        }
    }
}
