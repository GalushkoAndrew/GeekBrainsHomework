namespace GeekBrains.Learn.LoggerLib
{
    /// <summary>
    /// Logger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Sends message
        /// </summary>
        void SendLine(string value);
    }
}