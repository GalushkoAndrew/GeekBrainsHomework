using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.Metric.Controller;

namespace GeekBrains.Learn.Core.Tests
{
    public class DotnetMetricControllerTests : MetricControllerBaseTests
    {
        public DotnetMetricControllerTests() : base(new DotnetMetricController(new DotnetManager()))
        {
        }
    }
}
