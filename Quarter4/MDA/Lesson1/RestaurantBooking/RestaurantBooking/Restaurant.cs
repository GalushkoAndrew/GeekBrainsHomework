using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantBooking
{
    public class Restaurant
    {
        private const int _managerSpeed = 5000;
        private readonly ConcurrentBag<Table> _tables = new ConcurrentBag<Table>();
        private readonly CallCenter _callCenter = new CallCenter();
        public Restaurant()
        {
            for (ushort i = 1; i < 11; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int countOfPersons)
        {
            _callCenter
                .SendMessage("Добрый день! Подождите, я подберу столик и подтвержу бронь, оставайтесь на линии")
                .Wait();
            Thread.Sleep(_managerSpeed);
            var table = _tables
                .FirstOrDefault(x => x.SeatsCount > countOfPersons && x.State == Enums.State.Free);
            table?.SetState(Enums.State.Booked);
            _callCenter
                .SendMessage(table is null
                ? "К сожалению, сейчас все столики заняты"
                : $"Готово! Ваш столик номер {table.Id}")
                .Wait();
        }

        public void BookFreeTableAsync(int countOfPersons)
        {
            Task.Run(async () =>
            {
                await _callCenter
                    .SendMessage("Добрый день! Подождите, я подберу столик и подтвержу бронь, Вам придет уведомление");
                await Task.Delay(_managerSpeed);
                var table = _tables
                    .FirstOrDefault(x => x.SeatsCount > countOfPersons && x.State == Enums.State.Free);
                table?.SetState(Enums.State.Booked);
                await _callCenter.SendMessage(table is null
                    ? "К сожалению, сейчас все столики заняты"
                    : $"Готово! Ваш столик номер {table.Id}");
            });
        }

        public void RemoveReservation(int id)
        {
            _callCenter
                .SendMessage("Добрый день! Подождите, я сниму бронь")
                .Wait();
            Thread.Sleep(_managerSpeed);
            var table = _tables
                .FirstOrDefault(x => x.Id == id);
            if (table == null)
            {
                _callCenter
                    .SendMessage("У нас нет столика с таким номером")
                    .Wait();
                return;
            }
            if (table.State == Enums.State.Free)
            {
                _callCenter
                    .SendMessage("Указанный вами столик не зарезервирован")
                    .Wait();
                return;
            }
            table.SetState(Enums.State.Free);
            _callCenter
                .SendMessage("Бронь снята. Хорошего дня!")
                .Wait();
        }

        public void RemoveReservationAsync(int id)
        {
            Task.Run(async () =>
            {
                await _callCenter.SendMessage("Добрый день! Подождите, я сниму бронь, Вам придет уведомление");
                await Task.Delay(_managerSpeed);
                var table = _tables
                    .FirstOrDefault(x => x.Id == id);
                table?.SetState(Enums.State.Free);
                if (table == null)
                {
                    await _callCenter.SendMessage("У нас нет столика с таким номером");
                    return;
                }
                if (table.State == Enums.State.Free)
                {
                    await _callCenter.SendMessage("Указанный вами столик не зарезервирован");
                    return;
                }
                await _callCenter.SendMessage("Бронь снята. Хорошего дня!");
            });
        }

        public void BrokeReserving()
        {
            foreach (var table in _tables.Where(x => x.State ==  Enums.State.Booked))
            {
                table.SetState(Enums.State.Free);
                System.Console.WriteLine($"System.bug: table {table.Id} is free ...$$%%%#^%%%*(&(@$#%@^%...");
            }
        }
    }
}
