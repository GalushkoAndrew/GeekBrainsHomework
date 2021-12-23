using System.Collections.Generic;
using System.Text;

namespace GeekBrains.Learn.BuildingLibrary
{

    /// <summary>
    /// Тесты
    /// </summary>
    public sealed class Test
    {
        /// <summary>
        /// Запуск тестов
        /// </summary>
        public void Start()
        {
            ConsoleLogger consoleLogger = new();
            var building1 = BuildingFactory.Create(1, 1, 1, 1);
            consoleLogger.ShowMessage(building1.ToString());
            var building2 = BuildingFactory.Create(2, 2, 2, 2);
            consoleLogger.ShowMessage(building2.ToString());
            var building3 = BuildingFactory.Create(3, 3, 3, 3);
            consoleLogger.ShowMessage(building3.ToString());

            if (BuildingFactory.Find(building3))
            {
                consoleLogger.ShowMessage(building3.ToString() + " найдено");
            }
            else
            {
                consoleLogger.ShowMessage(building3.ToString() + " не найдено");
            }

            building3.HouseHigh = 100;
            consoleLogger.ShowMessage(building3.ToString());
            if (BuildingFactory.Find(building1))
            {
                consoleLogger.ShowMessage(building1.ToString() + " найдено");
            }
            else
            {
                consoleLogger.ShowMessage(building1.ToString() + " не найдено");
            }

            if (BuildingFactory.Find(building3))
            {
                consoleLogger.ShowMessage(building3.ToString() + " найдено");
            }
            else
            {
                consoleLogger.ShowMessage(building3.ToString() + " не найдено");
            }
        }
    }
}
