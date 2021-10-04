namespace GeekBrains.Learn.FunctionSimpleNumber
{
    /// <summary>
    /// Определяет, простое ли число
    /// </summary>
    class MathSimple
    {
        /// <summary>
        /// Определяет, простое ли число
        /// </summary>
        /// <param name="n">Проверяемое число</param>
        /// <returns>True, если число простое. False, если не простое</returns>
#pragma warning disable CA1822 // Пометьте члены как статические
        public bool IsSimple(int n)
#pragma warning restore CA1822 // Пометьте члены как статические
        {
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                return true;
            }

            return false;
        }
    }
}