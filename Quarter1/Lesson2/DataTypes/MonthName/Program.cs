using System;
using System.Globalization;

namespace GeekBrains.Learn.MonthName
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Month name is: " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(GetMonthNumber()));
        }
        public static int GetMonthNumber()
        {
            int monthNumber;
            while (true)
            {
                Console.Write("Input month number: ");
                var value = Console.ReadLine();
                if (!int.TryParse(value, out monthNumber)
                    || monthNumber < 1
                    || monthNumber > 12)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect!");
                }
                else
                    return monthNumber;
            }
        }
    }
}
