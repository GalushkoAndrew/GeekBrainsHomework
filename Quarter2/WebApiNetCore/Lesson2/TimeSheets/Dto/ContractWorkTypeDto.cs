using GeekBrains.Learn.Dto.Base;

namespace GeekBrains.Learn.Dto
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
