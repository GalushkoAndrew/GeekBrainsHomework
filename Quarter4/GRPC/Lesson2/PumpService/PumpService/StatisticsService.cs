using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PumpService
{
    public class StatisticsService : IStatisticsService
    {
        public int SuccessTacts { get; set; }
        public int ErrorTacts { get; set; }
        public int AllTacts { get; set; }
    }
}