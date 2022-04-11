using GeekBrains.Learn.TimeSheets.Dto.Base;

namespace GeekBrains.Learn.TimeSheets.Dto
{
    /// <summary>
    /// Invoice row
    /// </summary>
    public class InvoiceRowDto : IdentifierDto
    {
        /// <summary>
        /// Work
        /// </summary>
        public virtual WorkDto Work { get; set; }
    }
}
