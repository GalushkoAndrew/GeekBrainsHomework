using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Moq;

namespace GeekBrains.Learn.Core.MetricsAgent.ControllerTests
{
    /// <summary>
    /// base test class
    /// include logger object
    /// </summary>
    /// <typeparam name="T">controller class</typeparam>
    public abstract class LoggerTestBase<T>
        where T : class
    {
        private readonly Mock<ILogger<T>> _mockLogger;

        /// <summary>
        /// ctor
        /// </summary>
        public LoggerTestBase()
        {
            _mockLogger = new Mock<ILogger<T>>();
        }

        /// <summary>
        /// <see cref="Mock"/> <see cref="ILogger"/>
        /// </summary>
        protected Mock<ILogger<T>> Logger { get { return _mockLogger; } }

        /// <summary>
        /// Verify <see cref="ILogger"/> is called
        /// </summary>
        protected void VerifyLogger()
        {
            var regex = new Regex(@"Input parameters: fromTime = .+, toTime = .+");
            Logger.Verify(
                    m => m.Log(
                        LogLevel.Information,
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, _) => regex.IsMatch(v.ToString())),
                        null,
                        It.IsAny<Func<It.IsAnyType, Exception, string>>()));
        }
    }
}
