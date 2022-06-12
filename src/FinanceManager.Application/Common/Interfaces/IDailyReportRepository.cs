using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IDailyReportRepository
    {
        Task<DailyReport> GetDailyReportByIdAsync(int dailyReportId);
        Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take, string appUserId);
        Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take, string appUserId, Func<DailyReport, bool> conditions);
        Task<DailyReport> GetLastDailyReportAsync(string appUserId);
        Task<int> GetDailyReportCount(string appUserId);
        Task<DailyReport> GetDailyReport(string appUserId, Expression<Func<DailyReport, bool>> conditions);
    }
}
