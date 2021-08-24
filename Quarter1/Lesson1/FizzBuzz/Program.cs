using System;

namespace GeekBrains.Learn.FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int divisible1 = 3; // кратность 1
            int divisible2 = 5; // кратность 2
            int maxNumber = 100; // количество элементов для отображения
            int iteration = 0; // количество итераций
            string delimiter = ","; // разделитель элементов для вывода на экран
            var result = ""; // строка, выводимая на экран

            int period = divisible1 * divisible2; // периодичность повторения Fizz, Buzz
            string[] pattern = new string[period]; // массив-шаблон с повторяющейся последовательностью
            var listNumberIndex = new System.Collections.ObjectModel.Collection<int>(); // список индексов шаблона, по которым нужно изменять числа
            var countUsedArrayItems = period; // количество элементов шаблона, которое нужно вывести на экран

            // формируем шаблон с периодичностью повторения Fizz, Buzz
            for (int i = 0; i < period; i++)
            {
                bool isFizzBuzz = false;

                if ((i + 1) % 3 == 0)
                {
                    pattern[i] = "Fizz";
                    isFizzBuzz = true;
                }
                if ((i + 1) % 5 == 0)
                {
                    if (isFizzBuzz)
                    {
                        pattern[i] = pattern[i] + " " + "Buzz";
                    }
                    else
                        pattern[i] = "Buzz";
                    isFizzBuzz = true;
                }
                if (isFizzBuzz)
                {
                    pattern[i] = pattern[i];
                }
                else
                {
                    pattern[i] = (i + 1).ToString();
                    listNumberIndex.Add(i);
                }
            }
            iteration = period;
            result = String.Join(delimiter, pattern) + delimiter;
            Console.Write(result);

            // используем шаблон для вывода повторяющихся периодов последовательности
            var templateIteration = (int)Math.Ceiling((float)maxNumber / period);

            for (int t = 1; t < templateIteration; t++)
            {

                foreach (var item in listNumberIndex)
                {
                    iteration++;
                    int currentNumber = item + t * period + 1;
                    if (currentNumber > maxNumber)
                    {
                        countUsedArrayItems = maxNumber - (t) * period;
                        break;
                    }
                    pattern[item] = currentNumber.ToString();
                }

                result = String.Join(delimiter, pattern, 0, countUsedArrayItems);
                Console.Write(result);
                if (countUsedArrayItems == period && !(maxNumber == (t + 1) * period))
                    Console.Write(delimiter);
            }

            Console.WriteLine();
            Console.WriteLine("Iteration count: " + iteration);
        }
    }
}
