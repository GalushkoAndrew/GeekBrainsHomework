using System;

namespace GeekBrains.Learn.BuildingLibrary
{
    /// <summary>
    /// Класс логирования в консоль
    /// </summary>
    public sealed class ConsoleLogger : Logger
    {
        /// <inheritdoc/>
        public override void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
