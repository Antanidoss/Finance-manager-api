using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IDailyReportService
    {
        Task<Response<DailyReportDTO>> GetDailyReportByIdAsync(int dailyReportId);
        Task<Response<GetDailyReportsResponseModel>> GetDailyReportsAsync(int skip, int take);
        Task<Response<DailyReportDTO>> GetLastDailyReport();
    }
}
