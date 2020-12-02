using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IDailyReportService
    {
        Task<DailyReportViewModel> GetDailyReportByIdAsync(int dailyReportId);
        Task<GetDailyReportsResponceModel> GetDailyReportsAsync(int skip, int take);
        Task<DailyReportViewModel> GetLastDailyReport();
    }
}
