using GeekBrains.Learn.TimeSheets.Controllers.Base;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// Consumer controller
    /// </summary>
    public class ConsumerController : GeneralCrudController<Consumer, ConsumerDto>
    {
        /// <inheritdoc/>
        public ConsumerController(IManagerBase<Consumer, ConsumerDto> manager) : base(manager)
        {
        }
    }
}
