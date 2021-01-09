using FinanceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Persistence.Common.Context
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { Database.EnsureCreated(); }

        public DbSet<Report> Reports { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<DailyReport>().ToTable("DailyReports");
            base.OnModelCreating(modelBuilder);
        }
    }
}
