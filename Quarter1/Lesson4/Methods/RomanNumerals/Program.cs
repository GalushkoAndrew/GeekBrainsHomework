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

        static int? ConvertToArabicNumber(string romanNumber)
        {
            // проверки корректности числа
            int err1 = 0;
            int err5 = 0;
            int err10 = 0;
            int err50 = 0;
            int err100 = 0;
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
                        // проверки корректности числа
                        if (i > 0 && CharRomanToInt(romanNumber[i - 1]) < nextArabicNumber)
                            return null;

                        if (currentArabicNumber == 5 || currentArabicNumber == 50 || currentArabicNumber == 500)
                            return null;

                        result -= currentArabicNumber;
                    }
                    else
                        result += currentArabicNumber;
                }
                else
                    result += currentArabicNumber;

                // проверки корректности числа
                err5 += currentArabicNumber == 5 ? 1 : 0;
                err50 += currentArabicNumber == 50 ? 1 : 0;
                err500 += currentArabicNumber == 500 ? 1 : 0;

                err1 += currentArabicNumber == 1 ? 1 : 0;
                err10 += currentArabicNumber == 10 ? 1 : 0;
                err100 += currentArabicNumber == 100 ? 1 : 0;

            }

            // проверки корректности числа
            if (err5 > 1 || err50 > 1 || err500 > 1 || err1 > 3 || err10 > 3 || err100 > 3)
            {
                return null;
            }

            return result;
        }

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
