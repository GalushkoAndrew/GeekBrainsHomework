using GeekBrains.Learn.Core.DAO.Model.Base;
using System;

namespace GeekBrains.Learn.Core.DAO.Model.Models
{
    public class NetworkMetric : IBaseModel
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}
