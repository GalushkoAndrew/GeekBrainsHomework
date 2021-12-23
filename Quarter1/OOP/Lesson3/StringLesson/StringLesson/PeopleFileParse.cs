using System;
using System.IO;
using System.Linq;
using System.Text;

namespace GeekBrains.Learn.StringLesson
{
    /// <summary>
    /// Класс предназначен для парсинга файла input.txt с email-адресами
    /// Результат записывается в output.txt
    /// </summary>
    public class PeopleFileParse
    {
        const string inputFile = "input.txt";
        const string outputFile = "output.txt";
        /// <summary>
        /// Входной формат текстового файла:
        /// ФИО1&Mail1
        /// каждый человек помещается на новой строке
        /// </summary>
        public void StartParse()
        {
            StringMath stringMath = new();
            var text = File.ReadAllText(inputFile);

            string[] arrStrings = text.Split('\r', '\n').Where(x => !x.Equals("")).ToArray();
            StringBuilder stringBuilder = new();
            foreach (var item in arrStrings)
            {
                var s = item;
                stringMath.SeachMail(ref s);
                stringBuilder.Append(s + Environment.NewLine);
            }

            File.WriteAllText(outputFile, stringBuilder.ToString());
        }
    }
}
