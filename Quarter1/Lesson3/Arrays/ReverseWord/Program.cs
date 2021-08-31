using System;

namespace GeekBrains.Learn.ReverseWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите слово: ");
            var text = Console.ReadLine();
            for (int i = text.Length; i > 0; i--)
            {
                Console.Write(text[i - 1]);
            }
        }
    }
}
