using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicService.Data
{
    public class ClinicServiceDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountSession> AccountSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consultation>().HasOne(p => p.Pet).WithMany(b => b.Consultations).HasForeignKey(p => p.PetId).OnDelete(DeleteBehavior.NoAction);
        }

        public ClinicServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
