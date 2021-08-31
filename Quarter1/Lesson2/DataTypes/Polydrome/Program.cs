using System;
using System.Linq;

namespace GeekBrains.Learn.Polydrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringPolydrome();
            IntPolydrome();
        }

        static void StringPolydrome()
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

        static void IntPolydrome()
        {
            ulong x = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите целое число для определения палиндрома");
                var temp = Console.ReadLine();
                if (ulong.TryParse(temp, out x))
                    break;
            }

            int countNumbers = 0;
            ulong numberLeft = 0;
            ulong numberRight = 0;
            ulong tempRest = x;
            while (true)
            {
                tempRest /= 10;
                countNumbers++;
                if (tempRest == 0)
                    break;
            }

            ulong tempNumber = x;
            int halfCount = countNumbers / 2;
            ulong multiplier = (ulong)Math.Pow(10, halfCount - 1);

            for (int i = 0; i < countNumbers; i++)
            {
                if (i < halfCount)
                {
                    numberRight += tempNumber % 10 * multiplier;
                    multiplier /= 10;
                    tempNumber /= 10;
                    continue;
                }

                if (i == halfCount && (countNumbers % 2 == 1))
                {
                    tempNumber /= 10;
                }
                else
                {
                    numberLeft = tempNumber;
                    break;
                }
            }

            if (numberLeft == numberRight)
                Console.WriteLine("Это палиндром");
            else
                Console.WriteLine("Это не палиндром");

        }
    }
}
