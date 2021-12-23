using System;
using System.Text;

namespace GeekBrains.Learn.LoggerLib
{

    /// <summary>
    /// Console logger
    /// </summary>
    public sealed class ConsoleLogger : Logger, IConsoleLogger
    {
        /// <inheritdoc/>
        public override void SendLine(string value)
        {
            Console.WriteLine(value);
        }

        /// <inheritdoc/>
        public void Send(string value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Draw line
        /// </summary>
        /// <param name="lineLength">Lines length</param>
        public void DrawLine(int lineLength = 20)
        {
            SendLine(new StringBuilder().Append('-', lineLength).ToString());
        }
    }
}