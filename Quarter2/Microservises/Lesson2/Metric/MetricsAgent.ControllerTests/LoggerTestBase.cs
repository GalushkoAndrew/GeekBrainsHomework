using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Text.RegularExpressions;

namespace GeekBrains.Learn.Core.MetricsAgent.ControllerTests
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
