namespace GeekBrains.Learn.TimeSheets.Dto
{
    /// <summary>
    /// Invoice report row
    /// </summary>
    public class InvoiceReportRowDto
    {
        /// <summary>
        /// WorkType name
        /// </summary>
        public string WorkTypeName { get; set; }

        /// <summary>
        /// Employee name
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Labor costs
        /// </summary>
        public int TimeSpend { get; set; }

        /// <summary>
        /// Cost
        /// </summary>
        public int Cost { get; set; }
    }
}
