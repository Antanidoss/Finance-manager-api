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

        public async Task<DailyReport> GetDailyReportByIdAsync(int dailyReportId)
        {
            return await _context.DailyReports.FirstOrDefaultAsync(d => d.Id == dailyReportId);
        }

        public async Task<int> GetDailyReportCount(string appUserId)
        {
            return await _context.DailyReports
                .Where(d => d.AppUserId == appUserId)
                .CountAsync();
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take)
        {
            return await _context.DailyReports
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take, Func<DailyReport, bool> func)
        {
            return _context.DailyReports
                .Where(func)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public async Task<DailyReport> GetLastDailyReportAsync(string appUserId)
        {
            var dailyReports = await _context.DailyReports
                .Where(d => d.AppUserId == appUserId)
                .ToListAsync();

            return dailyReports.Count() != 0 
                ? dailyReports.Last() 
                : null;
        }
    }
}
