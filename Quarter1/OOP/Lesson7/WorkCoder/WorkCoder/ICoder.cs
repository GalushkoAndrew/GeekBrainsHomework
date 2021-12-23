namespace GeekBrains.Learn.WorkCoder
{
    public interface ICoder
    {
        /// <summary>
        /// Шифрует строку
        /// </summary>
        /// <param name="value">Текст</param>
        /// <returns>Возвращает зашифрованную строку</returns>
        string Encode(string value);
        /// <summary>
        /// Дешифрует строку
        /// </summary>
        /// <param name="value">Текст</param>
        /// <returns>Возвращает расшифрованную строку</returns>
        string Decode(string value);
    }
}
