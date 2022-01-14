using System;

namespace GeekBrains.Learn.Core.DAO.Model.Base
{
    public interface IBaseModel : IHaveId
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
