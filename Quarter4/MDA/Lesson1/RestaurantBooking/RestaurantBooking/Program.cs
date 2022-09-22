using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace RestaurantBooking
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var rest = new Restaurant();
            var trueAnswers = new List<int>() { 1, 2 };
            CallCenter _callCenter = new CallCenter();
            using var timer = new Timer(CallBack, rest, 0, 20000);
            while (true)
            {
                _callCenter.SendMessage("Привет! Желаете забронировать столик?" +
                    "\n1 - бронирование - мы уведомим Вас по смс (асинхронно)" +
                    "\n2 - бронирование - подождите на линии, мы Вас оповестим (синхронно)")
                    .Wait();
                if (!int.TryParse(Console.ReadLine(), out var choice) || !trueAnswers.Contains(choice))
                {
                    Console.WriteLine("Введите пожалуйста 1 или 2");
                    continue;
                }
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                switch (choice)
                {
                    case 1:
                        rest.BookFreeTableAsync(1);
                        break;
                    case 2:
                        rest.BookFreeTable(1);
                        break;
                    default:
                        break;
                }
                _callCenter.SendMessage("Спасибо за Ваше обращение!").Wait();
                stopWatch.Stop();
                var ts = stopWatch.Elapsed;
                Console.WriteLine($"Потрачено времени клиента: {ts.Seconds:00}:{ts.Milliseconds:00}");
            }
        }

        public static void CallBack(object param)
        {
            if (param is Restaurant)
            {
                ((Restaurant)param).BrokeReserving();
            }
        }
    }
}
