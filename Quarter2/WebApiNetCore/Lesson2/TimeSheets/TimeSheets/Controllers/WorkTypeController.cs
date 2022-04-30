using GeekBrains.Learn.TimeSheets.Controllers.Base;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// WorkType controller
    /// </summary>
    public class WorkTypeController : GeneralCrudController<WorkType, WorkTypeDto>
    {
        /// <inheritdoc/>
        public WorkTypeController(IManagerBase<WorkType, WorkTypeDto> manager) : base(manager)
        {
        }
    }
}
