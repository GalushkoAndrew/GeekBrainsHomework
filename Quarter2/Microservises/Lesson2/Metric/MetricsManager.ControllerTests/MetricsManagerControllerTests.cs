using GeekBrains.Learn.Core.MetricsAgent.ControllerTests;
using GeekBrains.Learn.Core.MetricsManager.Controller;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekBrains.Learn.Core.ControllerMetricsManagerTests
{
    /// <inheritdoc/>
    public class MetricsManagerControllerTests : LoggerTestBase<MetricsManagerController>
    {
        private readonly IMetricsManagerController _controller;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricsManagerControllerTests()
        {
            _controller = new MetricsManagerController(Logger.Object);
        }

        /// <summary>
        /// Unit test
        /// </summary>
        [Fact]
        public void TestList()
        {
            var result = _controller.Get();
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
