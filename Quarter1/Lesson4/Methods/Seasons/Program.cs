using System;

namespace GeekBrains.Learn.Seasons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите номер месяца: ");
            var value = Console.ReadLine();

            if (!Int32.TryParse(value, out int i) || i < 1 || i > 12)
                Console.WriteLine("Ошибка: введите число от 1 до 12");
            else
                Console.WriteLine(GetSeasonName(GetSeason(i)));
        }

        static Season GetSeason(int monthNumber) =>
            (Season)(monthNumber % 12 / 3);

        static string GetSeasonName(Season season)
        {
            return season switch
            {
                Season.Winter => "зима",
                Season.Spring => "весна",
                Season.Summer => "лето",
                Season.Autumn => "осень",
                _ => "",
            };
        }

        enum Season
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }
    }
}
