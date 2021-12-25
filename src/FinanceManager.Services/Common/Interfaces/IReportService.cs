using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.Report;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IReportService
    {
        Task<Result> AddReportAsync(ReportCreateModel model);
        Task<Result> RemoveReportAsync(int reportId);
        Task<Response<GetReportsResponseModel>> GetReportsAsync(int skip, int take, int dailyId);
        Task<Response<ReportDTO>> GetReportByIdAsync(int reportId);
        Task<Result> UpdatereportAsync(ReportUpdateModel model);
    }
}