using GeekBrains.Learn.TimeSheets.Dto.Base;

namespace GeekBrains.Learn.TimeSheets.Dto
{
    /// <summary>
    /// Contract's worktype
    /// </summary>
    public class ContractWorkTypeDto : IdentifierDto
    {
        /// <summary>
        /// WorkType
        /// </summary>
        public virtual WorkTypeDto WorkType { get; set; }

        /// <summary>
        /// Price per hour
        /// </summary>
        public int Price { get; set; }
    }
}
