using System;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.MetricsAgent.Controller;
using Moq;
using Xunit;

namespace GeekBrains.Learn.Core.MetricsAgent.ControllerTests
{
    public class CpuMetricControllerTests : MetricTestsBase<ICpuMetricsManager, CpuMetricController>
    {
        private readonly CpuMetricController _controller;

        public CpuMetricControllerTests() : base()
        {
            _controller = new CpuMetricController(Manager.Object, Logger.Object);
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
