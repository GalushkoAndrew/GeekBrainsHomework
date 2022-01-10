using GeekBrains.Learn.Core.Infrastructure.Manager;
using GeekBrains.Learn.Core.Metric.Controller;

namespace GeekBrains.Learn.Core.Tests
{
    public class CpuMetricControllerTests : MetricControllerBaseTests
    {
        public CpuMetricControllerTests() : base(new CpuMetricController(new CpuManager()))
        {
        }
    }
}
