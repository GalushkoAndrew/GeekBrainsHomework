using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.SortExample
{
    class MathBucketSort
    {
        public void BucketSort(int[] array)
        {
            int itemCount = array.Length;

            int xMin = int.MaxValue;
            int xMax = int.MinValue;
            // определяем минимальное и максимальное значение в массиве
            for (int i = 0; i < itemCount; i++)
            {
                if (xMin > array[i])
                {
                    xMin = array[i];
                }

                if (xMax < array[i])
                {
                    xMax = array[i];
                }
            }

            // определяем количество корзин
            int bucketCount = Math.Min(5, itemCount / 200 + 1);

            int difference = xMax - xMin + 1;

            if (bucketCount > difference)
            {
                bucketCount = difference;
            }

            // шаг для распределения по корзинам
            int step = difference / bucketCount;

            // сортируем по корзинам
            // сами корзины
            List<int[]> buckets = new List<int[]>();
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new int[itemCount]);
            }

            // количество помещенных в них элементов и граничные значения чисел
            // 0 - количество элементов
            // 1 - минимальное значение включительно
            // 2 - максимальное значение не включительно
            int[,] bucketSize = new int[bucketCount, 3];

            // определяем граничные значения в корзинах
            for (int i = 0; i < bucketCount; i++)
            {
                // min
                bucketSize[i, 1] = xMin + step * i;
                // max
                if (i == bucketCount - 1)
                {
                    bucketSize[i, 2] = xMax + 1;
                }
                else
                {
                    bucketSize[i, 2] = xMin + step * (i + 1);
                }
            }

            // размещение элементов в корзины
            for (int i = 0; i < itemCount; i++)
            {
                for (int j = 0; j < bucketCount; j++)
                {
                    int value = array[i];
                    if (value >= bucketSize[j, 1] &&
                        value < bucketSize[j, 2])
                    {
                        buckets[j][bucketSize[j, 0]] = value;
                        bucketSize[j, 0]++;
                    }
                }
            }

            //int[] result = new int[itemCount];
            for (int i = 0; i < bucketCount; i++)
            {
                if (bucketSize[i, 2] - bucketSize[i, 1] != 0)
                {
                    var t = buckets[i];
                    QuickSort(t, 0, bucketSize[i, 0] - 1);
                }
            }

            // склеиваем корзины
            int index = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                for (int j = 0; j < bucketSize[i, 0]; j++)
                {
                    array[index] = buckets[i][j];
                    index++;
                }
            }

            //return result;
        }

        private void QuickSort(int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];

            do
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }

                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSort(array, i, last);
            if (first < j)
                QuickSort(array, first, j);
        }

    }
}
