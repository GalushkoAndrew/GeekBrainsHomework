using GeekBrains.Learn.Core.MetricAgent.Controller;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekBrains.Learn.Core.Tests
{
    public class AgentControllerTests
    {
        IAgentController controller;
        public AgentControllerTests()
        {
            controller = new AgentController();
        }

        [Fact]
        public void TestList()
        {
            var result = controller.Get();
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
