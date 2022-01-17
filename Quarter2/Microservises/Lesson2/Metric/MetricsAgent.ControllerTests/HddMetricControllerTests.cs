using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.MetricsAgent.Controller;
using Moq;
using Xunit;

namespace GeekBrains.Learn.Core.MetricsAgent.ControllerTests
{
    public class HddMetricControllerTests : MetricTestsBase<IHddMetricsManager, HddMetricController>
    {
        private readonly HddMetricController _controller;

        public HddMetricControllerTests() : base()
        {
            _controller = new HddMetricController(Manager.Object, Logger.Object);
        }

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
