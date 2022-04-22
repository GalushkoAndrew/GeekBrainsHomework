using Microsoft.EntityFrameworkCore;

namespace GeekBrains.Learn.TimeSheets.Domain
{
    /// <summary>
    /// DbContext
    /// </summary>
    public class TimeSheetsDbContext : DbContext
    {
        /// <inheritdoc/>
        public TimeSheetsDbContext(DbContextOptions<TimeSheetsDbContext> options) : base(options)
        {
        }

        /// <inheritdoc/>
        public DbSet<Employee> Employees { get; set; }
    }
}
