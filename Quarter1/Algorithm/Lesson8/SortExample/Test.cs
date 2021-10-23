using System;

namespace GeekBrains.Learn.SortExample
{
    class Test
    {
        /// <summary>
        /// Генерация массива со значениями
        /// </summary>
        /// <param name="n">количество элементов</param>
        /// <returns></returns>
        private int[] ArrayGenerate(int n)
        {
            int[] arr = new int[n];
            Random rnd = new();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(1, n);
            }

            return arr;
        }

        public void Start()
        {
            int count = 1000;
            const int formatLength = 5;
            var arr = ArrayGenerate(count);
            MathBucketSort mathBucketSort = new();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1, formatLength} - {arr[i], formatLength}");
            }
            Console.WriteLine("----------------------------");

            mathBucketSort.BucketSort(arr);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1, formatLength} - {arr[i], formatLength}");
            }
        }
    }
}
