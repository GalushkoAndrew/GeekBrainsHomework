using System;
using System.Linq;

namespace GeekBrains.Learn.Polydrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для определения палиндрома");
            var value = Console.ReadLine();

            var halfLength = value.Length / 2;
            var valueLeft = value[0..halfLength];
            var valueRight = value[^halfLength..];
            var valueRightReverse = new string(valueRight.Reverse().ToArray());

            if (valueLeft.Equals(valueRightReverse))
                Console.WriteLine("Это палиндром");
            else
                Console.WriteLine("Это не палиндром");

        }
    }
}
