using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.Json;

namespace GeekBrains.Learn.AppConfig
{
    class Program
    {
        const string configName = "appsettings.json";

        static void Main(string[] args)
        {
            string pathConfig = Path.Combine(Directory.GetCurrentDirectory(), configName);
            string name = "";
            string yearsOld = "";
            string profession = "";
            string answer;
            Config config;
            IConfigurationRoot appConfig;

            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile(configName, optional: true, reloadOnChange: true);

            try
            {
                appConfig = configBuilder.Build();
                
                name = appConfig["Name"] ?? name;
                yearsOld = appConfig["YearsOld"] ?? yearsOld;
                profession = appConfig["Profession"] ?? profession;

                config = new Config();
                appConfig.Bind(config);
            }
            catch
            {
                config = new Config();
            }

            string greatingsName = name.Equals("") ? "Приветствую!" : $"Приветствую, {name}.";
            string greatingsProfession = profession.Equals("") ? " Ваша профессия неизвестна." : $" Вы {profession}.";
            string greatingsYearsOld = yearsOld.Equals("") ? " Ваш возраст неизвестен." : $" Ваш возраст {yearsOld}.";

            Console.WriteLine($"{greatingsName}{greatingsProfession}{greatingsYearsOld}");
            Console.WriteLine("Хотите изменить настройки? (y/n)");

            answer = Console.ReadLine();
            if (answer.Equals("n"))
            {
                Console.WriteLine("До свидания!");
                return;
            }

            Console.Write("Имя: ");
            config.Name = Console.ReadLine();
            Console.Write("Профессия: ");
            config.Profession = Console.ReadLine();
            Console.Write("Возраст: ");
            config.YearsOld = Console.ReadLine();

            var serializerOptions = new JsonSerializerOptions { WriteIndented = true };
            string jsonOut = JsonSerializer.Serialize(config, serializerOptions);
            File.WriteAllText(pathConfig, jsonOut);

            Console.WriteLine("Настройки сохранены!");
        }
    }

    class Config
    {
        public string Name { get; set; }
        public string YearsOld { get; set; }
        public string Profession { get; set; }
        public Config()
        {
            Name = "";
            YearsOld = "";
            Profession = "";
        }
    }
}
