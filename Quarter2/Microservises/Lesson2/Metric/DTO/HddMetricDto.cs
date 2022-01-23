using GeekBrains.Learn.Core.DTO.Base;
using System;

namespace GeekBrains.Learn.Core.DTO
{
    public class HddMetricDto : IMetricDto
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}
