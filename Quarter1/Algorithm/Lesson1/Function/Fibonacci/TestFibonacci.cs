using System;

namespace GeekBrains.Learn.Fibonacci
{
    class TestFibonacci
    {
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
