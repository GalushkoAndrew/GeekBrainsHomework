using GeekBrains.Learn.Core.Metric.Controller;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace GeekBrains.Learn.Core.Tests
{
    public abstract class MetricControllerBaseTests
    {
        IMetricController _controller;
        public MetricControllerBaseTests(IMetricController controller)
        {
            _controller = controller;
        }

        [Fact]
        public void GetMetricsFromAgentTest()
        {
            DateTime dateBegin = DateTime.Now.AddDays(-1);
            DateTime dateEnd = DateTime.Now.AddDays(1);

            var result = _controller.GetMetricsFromAgent(dateBegin, dateEnd);

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
