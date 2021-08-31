using System;

namespace GeekBrains.Learn.Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();
            int[,] array = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    array[i, j] = rnd.Next(100);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"[{i}, {i}] = {array[i, i]}");
            }
        }
    }
}
