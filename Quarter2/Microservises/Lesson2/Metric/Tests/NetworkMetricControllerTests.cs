using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.Metric.Controller;

namespace GeekBrains.Learn.Core.Tests
{
    public class NetworkMetricControllerTests : MetricControllerBaseTests
    {
        public NetworkMetricControllerTests() : base(new NetworkMetricController(new NetworkManager()))
        {
        }
    }
}
