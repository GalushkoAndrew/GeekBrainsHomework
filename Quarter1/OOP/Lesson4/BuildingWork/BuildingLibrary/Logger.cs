namespace GeekBrains.Learn.BuildingLibrary
{
    /// <summary>
    /// Базовый класс логирования сообщений
    /// </summary>
    public abstract class Logger
    {
        /// <summary>
        /// Отправка собщения в логгер
        /// </summary>
        /// <param name="message">Сообщение</param>
        public abstract void ShowMessage(string message);
    }
}
