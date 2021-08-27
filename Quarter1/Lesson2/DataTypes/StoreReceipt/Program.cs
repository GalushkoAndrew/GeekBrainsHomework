using System;

namespace GeekBrains.Learn.StoreReceipt
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new(2021, 8, 27, 10, 15, 2);
            decimal amount = 554.15m;
            string storeName = "RedFox";
            int INN = 1234567890;

            Console.WriteLine("КАССОВЫЙ ЧЕК");
            Console.WriteLine(storeName);
            Console.WriteLine("ИНН: " + INN);
            Console.WriteLine("Дата: " + date);
            Console.WriteLine(new String('-', 20));
            Console.WriteLine("ИТОГ: " + amount);
        }
    }
}
