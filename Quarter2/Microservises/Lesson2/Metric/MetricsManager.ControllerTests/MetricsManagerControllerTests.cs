using System.Text.RegularExpressions;
using GeekBrains.Learn.Core.Infrastructure.Manager.Interfaces;
using GeekBrains.Learn.Core.MetricsAgent.ControllerTests;
using GeekBrains.Learn.Core.MetricsManager.Controller;
using Moq;
using Xunit;

namespace GeekBrains.Learn.Core.ControllerMetricsManagerTests
{
    /// <inheritdoc/>
    public class MetricsManagerControllerTests : LoggerTestBase<MetricsManagerController>
    {
        private readonly MetricsManagerController _controller;
        private readonly Mock<IAgentManager> _mockManager;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricsManagerControllerTests()
        {
            _mockManager = new Mock<IAgentManager>();

            _controller = new MetricsManagerController(Logger.Object, _mockManager.Object);
        }

        /// <summary>
        /// Unit test
        /// </summary>
        [Fact]
        public void TestList()
        {
            var regex = new Regex(@"Input parameters: ");
            _mockManager.Setup(x => x.GetAll());
            _controller.Get();
            LoggerSetVerify(Logger, regex);
            _mockManager.VerifyAll();
        }
    }
}
