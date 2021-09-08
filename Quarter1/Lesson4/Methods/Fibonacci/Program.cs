using System;

namespace GeekBrains.Learn.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество итераций: ");
            if (!Int32.TryParse(Console.ReadLine(), out int i))
            {
                Console.WriteLine("Неверное число");
                return;
            }

            Console.WriteLine(GetFibonacci(i));
        }

        static ulong GetFibonacci(int itegations)
        {
            if (itegations == 0)
                return 0;
            if (itegations == 1)
                return 1;
            return CalcFibonacci(itegations - 1, 0, 1);
        }

        static ulong CalcFibonacci(int iterations, ulong lastNumber, ulong currentNumber)
        {
            iterations--;
            if (iterations == 0)
                return lastNumber + currentNumber;
            else
                return CalcFibonacci(iterations, currentNumber, lastNumber + currentNumber);
        }
    }
}
