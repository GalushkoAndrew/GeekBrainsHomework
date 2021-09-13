using System;

namespace GeekBrains.Learn.FullName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFullName("Иванов", "Иван", "Иванович"));
            Console.WriteLine(GetFullName("Петров", "Петр", "Петрович"));
            Console.WriteLine(GetFullName("Сидоров", "Сидор", "Сидорович"));
            Console.WriteLine(GetFullName("Пушкин", "Александр", "Сергеевич"));
        }

        static string GetFullName(string lastName, string firstName, string patronymicName)
        {
            return (lastName ?? "")
                + GetSpace(lastName, firstName)
                + (firstName ?? "")
                + GetSpace(patronymicName, firstName)
                + (patronymicName ?? "");
        }

        static string GetSpace(string name1, string name2)
        {
            if (name1 == null
                || name2 == null
                || name1.Equals("")
                || name2.Equals(""))
                return "";
            else
                return " ";
        }
    }
}
