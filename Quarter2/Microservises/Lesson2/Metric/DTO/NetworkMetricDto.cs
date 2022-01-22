using GeekBrains.Learn.Core.DTO.Base;
using System;

namespace GeekBrains.Learn.Core.DTO
{
    public class NetworkMetricDto : IBaseModelDto
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}
