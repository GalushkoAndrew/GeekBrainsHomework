using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBrains.Learn.FirstController
{
    /// <summary>
    /// Test model manager
    /// </summary>
    public class TemperatureManager
    {
        /// <summary>
        /// ctor
        /// </summary>
        public TemperatureManager()
        {
            ListTemperature = new List<Temperature>
            {
                new Temperature(new DateTime(2021, 1, 1), 10),
                new Temperature(new DateTime(2021, 1, 2), 11),
                new Temperature(new DateTime(2021, 1, 3), 12),
                new Temperature(new DateTime(2021, 1, 4), 13)
            };
        }

        private List<Temperature> ListTemperature { get; set; }

        /// <summary>
        /// Returns list of temperature filtered by dates
        /// </summary>
        /// <returns>Temperature List</returns>
        public List<Temperature> GetList(DateTime dateBegin, DateTime dateEnd)
        {
            return ListTemperature.Where(x => x.Date >= dateBegin && x.Date <= dateEnd).ToList();
        }

        /// <summary>
        /// Add temperature
        /// </summary>
        public bool Create(Temperature temperature)
        {
            if (temperature == null)
            {
                return false;
            }

            if (ListTemperature.Where(x => x.Date == temperature.Date).Any())
            {
                return false;
            }

            ListTemperature.Add(temperature);
            return true;
        }

        /// <summary>
        /// Edit temperature
        /// Find it by date-time
        /// </summary>
        public bool Update(Temperature temperature)
        {
            if (temperature == null)
            {
                return false;
            }

            var findedTemperature = ListTemperature.Where(x => x.Date == temperature.Date).FirstOrDefault();

            if (findedTemperature == null)
            {
                return false;
            }

            findedTemperature.Value = temperature.Value;
            return true;
        }

        /// <summary>
        /// Delete temperature by date period
        /// </summary>
        /// <returns>Count deleted values</returns>
        public int Delete(DateTime dateBegin, DateTime dateEnd)
        {
            var list = ListTemperature.Where(x => x.Date >= dateBegin && x.Date <= dateEnd);
            int count = list.Count();
            ListTemperature.RemoveAll(x => list.Contains(x));
            return count;
        }
    }
}
