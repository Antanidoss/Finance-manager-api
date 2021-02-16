using FinanceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Common.Context.Configuration
{
    public class DailyReportModelConfiguration : IEntityTypeConfiguration<DailyReport>
    {
        public void Configure(EntityTypeBuilder<DailyReport> builder)
        {
            builder.ToTable("DailyReports");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.AppUserId).IsRequired();
            builder.Property(d => d.TimeOfCreate).IsRequired();

            builder.HasOne(d => d.AppUser)
                .WithMany(a => a.DailyReports)
                .HasForeignKey(d => d.AppUserId);

            builder.HasMany(d => d.Reports)
                .WithOne(r => r.DailyReport)
                .HasForeignKey(r => r.DailyReportId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
