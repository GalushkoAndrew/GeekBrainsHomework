using GeekBrains.Learn.Dto.Base;

namespace GeekBrains.Learn.Dto
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
