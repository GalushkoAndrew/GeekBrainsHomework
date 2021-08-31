using System;

namespace GeekBrains.Learn.PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array = {
                { "Ben", "8-918-111-11-11" },
                { "Bob", "8-918-222-22-22" },
                { "Dick", "8-918-333-33-33" },
                { "Ted", "8-918-444-44-44" },
                { "Richard", "8-918-555-55-55" } };
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                Console.WriteLine($"User: {array[i, 0]}\t\tPhone: {array[i, 1]}");
            }
        }
    }
}
