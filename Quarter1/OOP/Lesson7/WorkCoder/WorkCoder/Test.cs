using GeekBrains.Learn.LoggerLib;

namespace GeekBrains.Learn.WorkCoder
{
    /// <summary>
    /// Tests
    /// </summary>
    internal sealed class Test
    {
        /// <summary>
        /// Starts tests
        /// </summary>
        public void Start()
        {
            string testString = "фывпрasdsdgjQSFAФАПРРЛЗ54 _";
            ACoder aCoder = new();
            BCoder bCoder = new();
            ConsoleLogger logger = new();

            logger.SendLine($"Исходная строка: {testString}");

            CoderTest(aCoder, logger, testString);
            CoderTest(bCoder, logger, testString);
        }

        private void CoderTest(ICoder coder, IConsoleLogger logger, string testString)
        {
            logger.DrawLine();
            logger.SendLine($"Тест {coder.GetType()}");
            var codedString = coder.Encode(testString);
            logger.SendLine($"Закодированно: {codedString}");
            logger.SendLine($"Раскодированно: {coder.Decode(codedString)}");
        }
    }
}
