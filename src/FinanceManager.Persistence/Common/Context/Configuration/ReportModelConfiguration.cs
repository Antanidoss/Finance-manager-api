using FinanceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Common.Context.Configuration
{
    public class ReportModelConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.DailyReportId).IsRequired();
            builder.Property(r => r.AmountSpent).IsRequired();
            builder.Property(r => r.DescriptionsOfExpenses).IsRequired();
            builder.Property(r => r.TimeOfCreate).IsRequired();

            builder.HasOne(r => r.DailyReport)
                .WithMany(d => d.Reports)
                .HasForeignKey(r => r.DailyReportId);
        }
    }
}
