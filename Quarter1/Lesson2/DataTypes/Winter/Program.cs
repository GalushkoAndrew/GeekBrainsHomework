using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int month = MonthName.Program.GetMonthNumber();
            List<int> winterMonths = new() { 1, 2, 12 };
            float temperature = AverageTemperature.Program.GetAverageTemperature();
            if (winterMonths.Contains(month) && temperature > 0)
                Console.WriteLine("Дождливая зима");
            else
                Console.WriteLine("Обычная зима");
        }
    }
}
