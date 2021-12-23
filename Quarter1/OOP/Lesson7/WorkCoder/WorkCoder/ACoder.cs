namespace GeekBrains.Learn.WorkCoder
{
    /// <summary>
    /// Работа с шифрованием
    /// Шифр - сдвиг символа на 1 вперед
    /// </summary>
    internal sealed class ACoder : ICoder
    {
        /// <inheritdoc/>
        public string Decode(string value)
        {
            return Code(value, DirectionCode.Backward);
        }

        /// <inheritdoc/>
        public string Encode(string value)
        {
            return Code(value, DirectionCode.Forward);
        }

        private static string Code(string value, DirectionCode direction)
        {
            string encodedValue = "";
            foreach (var character in value)
            {
                encodedValue += (char)((int)character + direction);
            }

            return encodedValue;
        }
    }
}
