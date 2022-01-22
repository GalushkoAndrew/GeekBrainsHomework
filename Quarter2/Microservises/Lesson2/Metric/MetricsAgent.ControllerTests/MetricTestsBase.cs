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
        where TEntity : IBaseModel
        where TDto : IBaseModelDto
    {
        private readonly Mock<IMetricsManager<TEntity, TDto>> _mockMetricsManager;

        public MetricTestsBase() : base()
        {
            _mockMetricsManager = new Mock<IMetricsManager<TEntity, TDto>>();
        }

        protected Mock<IMetricsManager<TEntity, TDto>> Manager { get { return _mockMetricsManager; } }
    }
}
