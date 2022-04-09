using System;
using System.Text.RegularExpressions;

namespace GeekBrains.Learn.RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "   Предложение  один    Теперь  предложение   два     Предложение    три    ";
            Console.WriteLine(str);

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            string res = regex.Replace(str, " ");

            regex = new Regex(@"^\s|\s$", options);
            res = regex.Replace(res, "");

            regex = new Regex(@"\s[А-Я]", options);
            var matches = regex.Matches(res);
            foreach (Match match in matches)
            {
                int index = res.IndexOf(match.Value);
                res = res.Insert(index, ".");
            }

            res += ".";

            Console.WriteLine(res);
        }
    }
}
