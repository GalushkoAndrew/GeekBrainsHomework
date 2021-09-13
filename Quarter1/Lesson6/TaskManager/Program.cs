using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TaskManager
{
    class Program
    {
        // 1.
        // tasklist показывает другие имена, а именно: System Idle Process; csrss.exe
        // а у меня они отображаются как: Idle; csrss

        // 2.
        // В tasklist есть поле Имя сессии
        // я получил его Id (process.SessionId), но не смог получить имя

        static void Main(string[] args)
        {
            PrintProcessList();

            while (true)
            {
                var command = Console.ReadLine();
                if (command.Equals("q"))
                    return;

                var arr = command.Split(' ');

                switch (arr.FirstOrDefault()?.ToLower() ?? "")
                {
                    case "/list":
                        PrintProcessList();
                        break;
                    case "/pid":
                        if (arr.Length < 1)
                            continue;

                        if (Int32.TryParse(arr[1], out int i))
                        {
                            try
                            {
                                Process.GetProcessById(i).Kill();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ошибка. " + ex.Message);
                            }
                        }

                        continue;
                    case "/im":
                        if (arr.Length < 1)
                            continue;

                        try
                        {
                            var killList = Process.GetProcessesByName(arr[1]);
                            foreach (var item in killList)
                            {
                                item.Kill();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка. " + ex.Message);
                        }

                        continue;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }

        static void PrintProcessList()
        {
            var format = new NumberFormatInfo();
            format.NumberGroupSeparator = " ";

            var processes = Process.GetProcesses().OrderBy(x => x.ProcessName);
            Console.WriteLine("Имя образа                     PID "
                //+ "Имя сессии       "
                + "   № сеанса       Память");
            Console.WriteLine(new string('=', 25)
                + ' ' + new string('=', 8)
                //+ ' ' + new string('=', 16)
                + ' ' + new string('=', 11)
                + ' ' + new string('=', 12));
            foreach (var process in processes)
            {
                Console.WriteLine($"{CutString(process.ProcessName, 25),-25}" +
                    $" {process.Id,8} "
                    //+ $"{process.SessionId, -16} "
                    + $"{process.SessionId,11} "
                    + $"{(process.WorkingSet64 / 1024).ToString("N0", format),9} KB"
                    );
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Введите команду");
            Console.WriteLine("q - выход");
            Console.WriteLine("/PID <номер процесса> - Идентификатор процесса, который требуется завершить");
            Console.WriteLine("/IM <название> - Название процесса, который требуется завершить");
            Console.WriteLine("/LIST - Список процессов");
        }

        static string CutString(string inputString, int length)
        {
            return inputString.Substring(0, inputString.Length > length ? length : inputString.Length);
        }
    }
}
