using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Persistence.Common.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly EFDbContext _context;

        public ReportRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task AddReportAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            return await _context.Reports.Include(p => p.DailyReport).FirstOrDefaultAsync(r => r.Id == reportId);
        }

        public async Task<int> GetReportCount(int dailyReportId)
        {
            return await _context.Reports
                .Where(p => p.DailyReportId == dailyReportId)
                .CountAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsAsync(int skip, int take, int dailyReportId)
        {
            return await _context.Reports
                .Where(r => r.DailyReportId == dailyReportId)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsAsync(int skip, int take, int dailyReportId, Func<Report, bool> func)
        {
            return  _context.Reports
                .Where(r => r.DailyReportId == dailyReportId)
                .Include(r => r.DailyReport)
                .Where(func)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public async Task RemoveReportAsync(Report report)
        {
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Report report)
        {
            var updateReport = await _context.Reports.FirstOrDefaultAsync(r => r.Id == report.Id);

            updateReport.AmountSpent = report.AmountSpent;
            updateReport.DescriptionsOfExpenses = report.DescriptionsOfExpenses;

            _context.Reports.Update(updateReport);
            await _context.SaveChangesAsync();
        }
    }
}
