using System;

namespace GeekBrains.Learn.Core.DAO.Model.Base
{
    public interface IMetric
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
