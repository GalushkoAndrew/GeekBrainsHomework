using System;
using System.IO;

namespace GeekBrains.Learn.TimeToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "startup.txt";
            File.AppendAllText(fileName, DateTime.Now.TimeOfDay.ToString() + Environment.NewLine);

            Console.WriteLine("В файле записано: " + File.ReadAllText(fileName));
        }
    }
}
