using System;

namespace GeekBrains.Learn.TalkWithAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            var inputText = Console.ReadLine();
            Console.WriteLine($"Hi, {inputText}, today {DateTime.Now.ToString("dd.MM.yyyy")}.");

            Console.WriteLine();
            Console.WriteLine(FormatAnswer("Any questions else? (No - exit)"));
            int counter = 0;
            while (true)
            {
                var inputTextLoop = Console.ReadLine();
                if (IsExit(inputTextLoop))
                {
                    Console.WriteLine(FormatAnswer("Bye-bye!"));
                    return;
                }
                Console.WriteLine(Answer(inputTextLoop));
                counter++;
                if (counter > 5)
                {
                    Console.WriteLine(FormatAnswer("I'm tired. Bye-bye!"));
                    return;
                }
            }
        }

        static bool IsExit(string text)
        {
            if (text.ToLower().StartsWith("no"))
                return true;
            return false;
        }

        static string Answer(string text)
        {
            return FormatAnswer(
                text.ToLower() switch
                {
                    "hello" => "World",
                    "world" => "Hello",
                    "boo" => "Foo",
                    "foo" => "Boo",
                    "name" => "No, your Name?",
                    "yes" => "Go on.",
                    "capital" => "London is a capital of Great Britain",
                    _ => "You are strange...",
                });
        }

        static string FormatAnswer(string text)
        {
            return "AI " + $"[{DateTime.Now}]: " + text;
        }
    }
}
