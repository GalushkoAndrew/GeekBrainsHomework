using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.Metric.Controller;

namespace GeekBrains.Learn.Core.Tests
{
    public class RamMetricControllerTests : MetricControllerBaseTests
    {
        public RamMetricControllerTests() : base(new RamMetricController(new RamManager()))
        {
        }
    }
}
