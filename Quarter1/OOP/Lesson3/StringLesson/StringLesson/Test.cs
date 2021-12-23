using System;

namespace GeekBrains.Learn.StringLesson
{
    public class Test
    {
        public void Start()
        {
            StringMath stringMath = new();
            Console.Write("Введите слово: ");
            var text = Console.ReadLine();
            var newText = stringMath.ReverseString(text);
            Console.WriteLine($"Текст в обратном порядке: {newText}");
            Console.WriteLine("--------");
            PeopleFileParse peopleFileParse = new();
            peopleFileParse.StartParse();
            Console.WriteLine("Файл output.txt сформирован");
            Console.WriteLine("--------");
        }
    }
}
