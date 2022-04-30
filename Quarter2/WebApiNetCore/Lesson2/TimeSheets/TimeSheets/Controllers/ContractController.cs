using GeekBrains.Learn.TimeSheets.Controllers.Base;
using GeekBrains.Learn.TimeSheets.Domain;
using GeekBrains.Learn.TimeSheets.Dto;
using GeekBrains.Learn.TimeSheets.Infrastructure.Managers.Base;

namespace GeekBrains.Learn.TimeSheets.Controllers
{
    /// <summary>
    /// Contract controller
    /// </summary>
    public class ContractController : GeneralCrudController<Contract, ContractDto>
    {
        /// <inheritdoc/>
        public ContractController(IManagerBase<Contract, ContractDto> manager) : base(manager)
        {
        }
    }
}
