using GeekBrains.Learn.Core.MetricAgent.Controller;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekBrains.Learn.Core.Tests
{
    public class MetricsManagerControllerTests : LoggerTestBase<MetricsManagerController>
    {
        private readonly IMetricsManagerController controller;

        public MetricsManagerControllerTests()
        {
            controller = new MetricsManagerController(Logger.Object);
        }

        [Fact]
        public void TestList()
        {
            var result = controller.Get();
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
