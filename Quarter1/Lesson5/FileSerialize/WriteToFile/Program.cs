using System;
using System.IO;

namespace GeekBrains.Learn.WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "text.txt";
            var text = Console.ReadLine();
            File.WriteAllText(fileName, text);

            Console.WriteLine("В файле записано: " + File.ReadAllText(fileName));
        }
    }
}
