namespace GeekBrains.Learn.Fibonacci
{
    /// <summary>
    /// Класс для расчета числа Фибоначчи
    /// </summary>
    class MathFibonacci
    {
        /// <summary>
        /// Рассчитывает число Фибоначчи
        /// </summary>
        /// <param name="itegrations">Количество итераций расчета</param>
        /// <returns>Число Фибоначчи</returns>
        public ulong GetFibonacci(int itegrations)
        {
            if (itegrations == 0)
                return 0;
            if (itegrations == 1)
                return 1;
            return CalcFibonacci(itegrations - 1, 0, 1);
        }

        private ulong CalcFibonacci(int iterations, ulong lastNumber, ulong currentNumber)
        {
            iterations--;
            if (iterations == 0)
                return lastNumber + currentNumber;
            else
                return CalcFibonacci(iterations, currentNumber, lastNumber + currentNumber);
        }
    }
}
