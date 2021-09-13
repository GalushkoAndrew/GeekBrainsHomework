using System;

namespace GeekBrains.Learn.RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите римское число: ");
            var romanNumber = Console.ReadLine();
            var result = ConvertToArabicNumber(romanNumber);
            if (result == null)
                Console.WriteLine("Число введено неверно");
            else
                Console.WriteLine(result);
        }

        /// <summary>
        /// Конвертация римского числа в арабское с проверками
        /// </summary>
        /// <param name="romanNumber"></param>
        /// <returns>Если римское число введено корректно, возвращает соответствующее арабское число. Иначе возвращает null</returns>
        static int? ConvertToArabicNumber(string romanNumber)
        {
            // проверки корректности числа
            int err1 = 0;
            int err5 = 0;
            int err10 = 0;
            int err10InARow = 0;
            int err50 = 0;
            int err100 = 0;
            int err100InARow = 0;
            int err500 = 0;
            int result = 0;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                int currentArabicNumber = CharRomanToInt(romanNumber[i]);
                if (i < romanNumber.Length - 1)
                {
                    int nextArabicNumber = CharRomanToInt(romanNumber[i + 1]);
                    if (currentArabicNumber < nextArabicNumber)
                    {
                        // два меньших числа не могут предшествовать большему
                        if (i > 0 && CharRomanToInt(romanNumber[i - 1]) < nextArabicNumber)
                            return null;

                        // V, L, D не могут предшествовать большему символу
                        if (currentArabicNumber == 5 || currentArabicNumber == 50 || currentArabicNumber == 500)
                            return null;

                        // допустимые сочетания уменьшения IX, XC или CM
                        if (!IsCorrectFollowNumber(currentArabicNumber, nextArabicNumber))
                            return null;

                        result -= currentArabicNumber;
                    }
                    else
                    {
                        result += currentArabicNumber;

                        // C и X не могут идти подряд более 3-х раз
                        err10InARow += currentArabicNumber == nextArabicNumber && currentArabicNumber == 10 ? err10InARow == 0 ? 2 : 1 : 0;
                        err100InARow += currentArabicNumber == nextArabicNumber && currentArabicNumber == 100 ? err100InARow == 0 ? 2 : 1 : 0;
                    }
                }
                else
                    result += currentArabicNumber;

                // Ограничения на количество одинаковых символов в числе.
                // Например, V, L, D не могут встречаться более 1 раза,
                // I не может встретиться более 3-х раз
                // X, C не могут встретиться более 4-х раз, например XXXIX
                err5 += currentArabicNumber == 5 ? 1 : 0;
                err50 += currentArabicNumber == 50 ? 1 : 0;
                err500 += currentArabicNumber == 500 ? 1 : 0;

                err1 += currentArabicNumber == 1 ? 1 : 0;
                err10 += currentArabicNumber == 10 ? 1 : 0;
                err100 += currentArabicNumber == 100 ? 1 : 0;
            }

            // проверки корректности числа
            if (err5 > 1 || err50 > 1 || err500 > 1 || err1 > 3 || err10 > 4 || err100 > 4 || err10InARow > 3 || err100InARow > 3)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Проверяет, чтобы уменьшение числа было корректно
        /// например, верны IX, XC или CM
        /// </summary>
        /// <param name="currentArabicNumber">текущий символ арабским числом</param>
        /// <param name="nextArabicNumber">следующий символ арабским числом</param>
        /// <returns>Возвращает ИСТИНА, если сочетание чисел допустимо</returns>
        static bool IsCorrectFollowNumber(int currentArabicNumber, int nextArabicNumber)
        {
            if (currentArabicNumber * 10 == nextArabicNumber)
                return true;

            return false;
        }

        /// <summary>
        /// Конвертирует римский символ в арабский
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Возвращает арабское число</returns>
        static int CharRomanToInt(char value)
        {
            return value switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };
        }
    }
}
