using System;

namespace GeekBrains.Learn.EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            while (true)
            {
                Console.Write("Введите целое число: ");
                var value = Console.ReadLine();
                if (!int.TryParse(value, out number))
                {
                    Console.Clear();
                    Console.WriteLine("Число не корректно!");
                }
                else
                    break;
            }

            if (number % 2 == 0)
                Console.WriteLine("Число четное");
            else
                Console.WriteLine("Число не четное");
        }
    }
}
