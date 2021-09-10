using System;
using System.IO;

namespace GeekBrains.Learn.BinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "arrayBin.bin";
            Console.WriteLine("Введите через пробел неколько чисел от 0 до 255");
            var text = Console.ReadLine();
            var arrayText = text.Split(' ');
            byte[] arrayByte = new byte[arrayText.Length];

            for (int i = 0; i < arrayText.Length; i++)
            {
                byte byteParced = 0;
                if (!byte.TryParse(arrayText[i], out byteParced))
                {
                    Console.WriteLine("Введены неверные числа");
                    return;
                };

                arrayByte[i] = byteParced;
            }

            File.WriteAllBytes(fileName, arrayByte);

            Console.WriteLine("В файле записано: ");
            foreach (var item in File.ReadAllBytes(fileName))
            {
                Console.Write(item.ToString() + " ");
            }
        }
    }
}
