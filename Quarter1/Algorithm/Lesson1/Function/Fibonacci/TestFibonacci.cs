using System;

namespace GeekBrains.Learn.Fibonacci
{
    /// <summary>
    /// Тест класса <see cref="MathFibonacci"/>
    /// </summary>
    class TestFibonacci
    {
        /// <summary>
        /// ctor
        /// </summary>
        public TestFibonacci()
        {
            MathFibonacci mathFibonacci = new();
            int[] array = new int[] { 5, 7, 14, 20, 26 };
            foreach (var i in array)
            {
                ulong fibonacci = mathFibonacci.GetFibonacci(i);
                Console.WriteLine($"{i}-е число Фибоначчи = {fibonacci}");
            }
        }
    }
}
