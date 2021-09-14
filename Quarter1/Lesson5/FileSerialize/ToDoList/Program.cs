using System;
using System.IO;
using System.Text.Json;

namespace GeekBrains.Learn.ToDoList
{
    class Program
    {
        const string configFile = "config.json";
        static void Main(string[] args)
        {
            TasksInit();
            var toDos = DeserializeArray(configFile);
            while (true)
            {
                int taskNumber = 0;
                PrintToDoList(toDos);
                var inputCommand = Console.ReadLine();
                if (inputCommand.ToLower().Equals("q"))
                    return;
                if (Int32.TryParse(inputCommand, out taskNumber))
                {
                    if (taskNumber > 0 && taskNumber <= toDos.Length)
                    {
                        toDos[taskNumber - 1].IsDone = !toDos[taskNumber - 1].IsDone;
                        SerializeAndSaveArray(toDos);
                    }
                }
            }
        }

        static void TasksInit()
        {
            if (!File.Exists(configFile))
            {
                var array = new ToDo[5];
                array[0] = new ToDo { Title = "Покормить cat" };
                array[1] = new ToDo { Title = "Сделать домашнюю работу" };
                array[2] = new ToDo { Title = "Пообедать" };
                array[3] = new ToDo { Title = "Посмотреть сериал" };
                array[4] = new ToDo { Title = "Поужинать" };

                SerializeAndSaveArray(array);
            }
        }

        static void SerializeAndSaveArray(ToDo[] array)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            var json = JsonSerializer.Serialize(array, options);
            File.WriteAllText(configFile, json);
        }

        /// <summary>
        /// Загружает из файла массив и десериализует его
        /// </summary>
        /// <param name="fileName">Файл с сериализованными задачами</param>
        /// <returns>Массив задач</returns>
        static ToDo[] DeserializeArray(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var result = JsonSerializer.Deserialize<ToDo[]>(json);
            return result;
        }

        /// <summary>
        /// Выводит список задач на экран
        /// </summary>
        /// <param name="toDos"></param>
        static void PrintToDoList(ToDo[] toDos)
        {
            // add - добавление задачи
            // del - удаление задачи
            // номер задачи - отметка, что задача выполнена

            Console.Clear();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("q - выход");
            Console.WriteLine("Номер задачи - изменить отметку о выполнении");
            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < toDos.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {(toDos[i].IsDone ? "[x]" : "   ")} {toDos[i].Title}");
            }

            Console.WriteLine(new string('-', 20));
        }
    }

    /// <summary>
    /// Задача
    /// </summary>
    class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public ToDo()
        {
            Title = "";
            IsDone = false;
        }
    }
}
