using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IDailyReportRepository
    {
        Task<DailyReport> GetDailyReportByIdAsync(int dailyReportId);
        Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take, string appUserId);
        Task<IEnumerable<DailyReport>> GetDailyReportsAsync(int skip, int take, string appUserId, Func<DailyReport, bool> func);
        Task<DailyReport> GetLastDailyReportAsync(string appUserId);
        Task<int> GetDailyReportCount(string appUserId);
    }
}
