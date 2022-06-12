using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinanceManager.Persistence.Common.Repositories
{
    public class DailyReportRepository : IDailyReportRepository
    {
        private readonly EFDbContext _context;

        public DailyReportRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task AddDailyReportAsync(DailyReport dailyReport)
        {
            _context.DailyReports.Add(dailyReport);
            await _context.SaveChangesAsync();
        }

        public async Task<DailyReport> GetDailyReport(string appUserId, Expression<Func<DailyReport, bool>> conditions)
        {
            return await _context.DailyReports
                .Where(d => d.AppUserId == appUserId)
                .Include(d => d.Reports)
                .FirstOrDefaultAsync(conditions);
        }

        public async Task<DailyReport> GetDailyReportByIdAsync(int dailyReportId)
        {
            return await _context.DailyReports
                .Include(d => d.Reports)
                .FirstOrDefaultAsync(d => d.Id == dailyReportId);
        }

        public async Task<int> GetDailyReportCount(string appUserId)
        {
            return await _context.DailyReports
                .Where(d => d.AppUserId == appUserId)
                .CountAsync();
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take, string appUserId)
        {
            return await _context.DailyReports
                .Where(d => d.AppUserId == appUserId)
                .Skip(skip)
                .Take(take)
                .Include(d => d.Reports)
                .ToListAsync();
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take, string appUserId,
            Func<DailyReport, bool> func)
        {
            return _context.DailyReports
                .Where(d => d.AppUserId == appUserId)
                .Include(d => d.Reports)
                .Where(func)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public async Task<DailyReport> GetLastDailyReportAsync(string appUserId)
        {
            var dailyReports = await _context.DailyReports
                .Where(d => d.AppUserId == appUserId)
                .Include(d => d.Reports)
                .ToListAsync();

            return dailyReports.Count() != 0
                ? dailyReports.Last()
                : null;
        }
    }
}
