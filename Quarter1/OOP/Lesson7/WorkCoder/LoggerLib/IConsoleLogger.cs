namespace GeekBrains.Learn.LoggerLib
{
    public interface IConsoleLogger : ILogger
    {
        void Send(string value);
        void DrawLine(int lineLength = 20);
    }
}