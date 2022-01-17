using Moq;

namespace GeekBrains.Learn.Core.MetricsAgent.ControllerTests
{
    /// <summary>
    /// Base test class
    /// include manager object
    /// </summary>
    /// <typeparam name="IT">class interface</typeparam>
    /// <typeparam name="T">class</typeparam>
    public abstract class MetricTestsBase<IT, T> : LoggerTestBase<T>
        where T : class
        where IT : class
    {
        private readonly Mock<IT> _mockMetricsManager;

        public MetricTestsBase() : base()
        {
            _mockMetricsManager = new Mock<IT>();
        }

        protected Mock<IT> Manager { get { return _mockMetricsManager; } }
    }
}
