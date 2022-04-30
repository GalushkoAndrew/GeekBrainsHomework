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

        /// <inheritdoc/>
        public DbSet<Consumer> Consumers { get; set; }

        /// <inheritdoc/>
        public DbSet<Contract> Contracts { get; set; }

        /// <inheritdoc/>
        public DbSet<ContractWorkType> ContractWorkTypes { get; set; }

        /// <inheritdoc/>
        public DbSet<Invoice> Invoices { get; set; }

        /// <inheritdoc/>
        public DbSet<InvoiceRow> InvoiceRows { get; set; }

        /// <inheritdoc/>
        public DbSet<Work> Works { get; set; }

        /// <inheritdoc/>
        public DbSet<WorkType> WorkTypes { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasIndex(x => x.Name)
                .IsUnique();
            modelBuilder.Entity<Consumer>()
                .HasIndex(x => x.Name)
                .IsUnique();
            modelBuilder.Entity<Contract>()
                .HasIndex(x => x.Name)
                .IsUnique();
            modelBuilder.Entity<ContractWorkType>()
                .HasOne<Contract>()
                .WithMany(x => x.Rows);
            modelBuilder.Entity<ContractWorkType>()
                .HasIndex(x => new { x.ContractId, x.WorkTypeId })
                .IsUnique();
            modelBuilder.Entity<InvoiceRow>()
                .HasIndex(x => new { x.InvoiceId, x.WorkId })
                .IsUnique();
            modelBuilder.Entity<WorkType>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
