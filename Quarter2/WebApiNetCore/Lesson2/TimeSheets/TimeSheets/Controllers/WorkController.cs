using GeekBrains.Learn.TimeSheets.Controllers.Base;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// Work controller
    /// </summary>
    public class WorkController : GeneralCrudController<Work, WorkDto>
    {
        /// <inheritdoc/>
        public WorkController(IManagerBase<Work, WorkDto> manager) : base(manager)
        {
        }
    }
}
