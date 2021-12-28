using System;

namespace GeekBrains.Learn.FirstController
{
    /// <summary>
    /// Model temperature
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Temperature()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public Temperature(DateTime date, int value)
        {
            Date = date;
            Value = value;
        }

        /// <summary>
        /// Temperature date-time
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Temperature value
        /// </summary>
        public int Value { get; set; }
    }
}
