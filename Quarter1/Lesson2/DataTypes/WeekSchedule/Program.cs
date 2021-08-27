using System;

namespace GeekBrains.Learn.WeekSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            OfficeSchedule office1 = new(
                WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday | WeekDays.Friday,
                "Office1");
            OfficeSchedule office2 = new(
                WeekDays.Saturday | WeekDays.Sunday | WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday | WeekDays.Friday,
                "Office2");
            //Console.WriteLine((int)t);
            Console.WriteLine($"В {office1.Name} расписание: {office1.Schedule}");
            Console.WriteLine($"В {office2.Name} расписание: {office2.Schedule}");
        }
    }

    class OfficeSchedule
    {
        public WeekDays Schedule { get; set; }
        public string Name { get; set; }

        public OfficeSchedule(WeekDays schedule, string name)
        {
            Schedule = schedule;
            Name = name;
        }
    }

    [Flags]
    enum WeekDays
    {
        Monday = 1,
        Tuesday = 1 << 1,
        Wednesday = 1 << 2,
        Thursday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6
    }
}
