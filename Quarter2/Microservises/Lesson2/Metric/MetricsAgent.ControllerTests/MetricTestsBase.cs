using GeekBrains.Learn.Core.DAO.Model.Base;
using GeekBrains.Learn.Core.DTO.Base;
using GeekBrains.Learn.Core.Infrastructure.Manager;
using Moq;

namespace GeekBrains.Learn.Core.MetricsAgent.ControllerTests
{
    /// <summary>
    /// Base test class
    /// include manager object
    /// </summary>
    /// <typeparam name="TEntity">entity</typeparam>
    /// <typeparam name="TDto">dto</typeparam>
    /// <typeparam name="T">class</typeparam>
    public abstract class MetricTestsBase<TEntity, TDto, T> : LoggerTestBase<T>
        where T : class
        where TEntity : IMetric
        where TDto : IMetricDto
    {
        private readonly Mock<IMetricsManager<TEntity, TDto>> _mockMetricsManager;

        /// <summary>
        /// ctor
        /// </summary>
        public MetricTestsBase() : base()
        {
            _mockMetricsManager = new Mock<IMetricsManager<TEntity, TDto>>();
        }

        /// <summary>
        /// <see cref="Mock"/> <see cref="IMetricsManager<>"/>
        /// </summary>
        protected Mock<IMetricsManager<TEntity, TDto>> Manager { get { return _mockMetricsManager; } }
    }
}
