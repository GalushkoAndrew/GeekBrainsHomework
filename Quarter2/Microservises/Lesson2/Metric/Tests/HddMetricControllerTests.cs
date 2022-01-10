using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.Metric.Controller;

namespace GeekBrains.Learn.Core.Tests
{
    public class HddMetricControllerTests : MetricControllerBaseTests
    {
        public HddMetricControllerTests() : base(new HddMetricController(new HddManager()))
        {
        }
    }
}
