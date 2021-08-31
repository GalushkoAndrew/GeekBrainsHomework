using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.SearchForSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку 1: ");
            var s1 = Console.ReadLine();
            Console.Write("Введите строку 2: ");
            var s2 = Console.ReadLine();
            string result = "";

            List<string> list = new();

            string textMin = s1.Length <= s2.Length ? s1 : s2;
            string textMax = s1.Length > s2.Length ? s1 : s2;

            for (int i = 0; i < textMin.Length; i++)
            {
                for (int j = i; j < textMin.Length; j++)
                {
                    var textBlock = textMin[i..(j + 1)];
                    if (textBlock.Length > result.Length
                        && textMax.IndexOf(textBlock) > -1)
                        result = textBlock;
                }
            }


            Console.WriteLine(result);
        }
    }
}
