using System;

namespace GeekBrains.Learn.Core.DTO.Base
{
    public interface IBaseModelDto : IHaveIdDto
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
