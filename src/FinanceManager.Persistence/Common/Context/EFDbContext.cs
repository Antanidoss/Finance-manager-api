using FinanceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Persistence.Common.Context
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }

        public DbSet<Report> Reports { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
    }
}
