using FinanceManager.Domain.Entities;
using FinanceManager.Persistence.Common.Context.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Persistence.Common.Context
{
    public class EFDbContext : IdentityDbContext<AppUser>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }

        public DbSet<Report> Reports { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfiguration(new ReportModelConfiguration());
            modelBuilder.ApplyConfiguration(new DailyReportModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
