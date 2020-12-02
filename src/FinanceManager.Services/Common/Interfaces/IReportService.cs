using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels.Report;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IReportService
    {
        Task<Result> AddReportAsync(ReportCreateModel model);
        Task<Result> RemoveReportAsync(int reportId);
        Task<GetReportsResponceModel> GetReportsAsync(int skip, int take, int dailyId);
        Task<ReportViewModel> GetReportByIdAsync(int reportId);
        Task<Result> UpdatereportAsync(ReportUpdateModel model);
    }
}
