using System;
using System.Linq;

namespace GeekBrains.Learn.BinarySearch
{
    class Test
    {
        public void StartTest()
        {
            int arrSize = 20;
            int[] arr = new int[arrSize];

            Random rand = new();
            for (int i = 0; i < arrSize; i++)
            {
                arr[i] = rand.Next(1, 1000);
            }
            arr = arr.OrderBy(x => x).ToArray();
            for (int i = 0; i < arrSize; i++)
            {
                Console.Write($"{arr[i]} - ");
            }
            Console.WriteLine();

            int value = arr[rand.Next(0, arrSize - 1)];
            Console.WriteLine($"Ищем {value}");
            SearchMath searchMath = new();
            var result = searchMath.BinarySearch(arr, value);
            Console.WriteLine($"Индекс искомого числа: {result}");
        }
    }
}
