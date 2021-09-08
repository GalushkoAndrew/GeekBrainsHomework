using System;

namespace GeekBrains.Learn.ParseAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите подряд целые числа, разделенные пробелом.");
            int? result = GetSum(Console.ReadLine());
            if (result == null)
                Console.WriteLine("Ошибка. Один из введенных элементов не целое число");
            else
                Console.WriteLine($"Сумма: {result}");
        }

        static int? GetSum(string value)
        {
            int i = 0;
            string[] array = value.Split(' ');
            foreach (var item in array)
            {
                if (!Int32.TryParse(item, out int intItem))
                {
                    return null;
                }

                i += intItem;
            }

            return i;
        }
    }
}
