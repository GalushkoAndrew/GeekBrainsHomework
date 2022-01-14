using Microsoft.Extensions.Logging;
using Moq;

namespace GeekBrains.Learn.Core.Tests
{
    /// <summary>
    /// base test class
    /// include logger object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class LoggerTestBase<T>
        where T : class
    {
        private readonly Mock<ILogger<T>> _mockLogger;

        public LoggerTestBase()
        {
            _mockLogger = new Mock<ILogger<T>>();
        }

        protected Mock<ILogger<T>> Logger { get { return _mockLogger; } }
    }
}
