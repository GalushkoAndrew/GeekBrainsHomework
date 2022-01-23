using System;

namespace GeekBrains.Learn.Core.DTO.Base
{
    public interface IMetricDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
