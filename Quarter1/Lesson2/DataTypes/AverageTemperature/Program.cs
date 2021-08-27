using System;

namespace GeekBrains.Learn.AverageTemperature
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculate average temperature for the day.");

            Console.WriteLine($"Average temperature is {GetAverageTemperature()}");
        }

        private static int GetTemperature(string message)
        {
            Console.Write(message);
            int result;
            while (true)
            {
                var stringTemperature = Console.ReadLine();
                if (int.TryParse(stringTemperature, out result))
                    break;
                else
                    Console.Write("Incorrect number. " + message);
            }
            return result;
        }

        public static float GetAverageTemperature()
        {
            var minTemperature = GetTemperature("Input minimum temperature: ");
            var maxTemperature = GetTemperature("Input maximum temperature: ");
            return (float)(minTemperature + maxTemperature) / 2;
        }
    }
}
