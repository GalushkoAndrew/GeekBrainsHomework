﻿using CardStorageService;

namespace Account.Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = PasswordUtils.CreatePasswordHash("123");
            Console.ReadKey();
        }
    }
}