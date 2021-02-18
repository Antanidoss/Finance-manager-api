using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.DailyReports.Query.GetDailyReportById;
using FinanceManager.Application.DailyReports.Query.GetDailyReports;
using FinanceManager.Application.DailyReports.Query.GetDailyReportsCount;
using FinanceManager.Application.DailyReports.Query.GetLastDailyReport;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using MediatR;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userService;
        public DailyReportService(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }
        public async Task<Response<DailyReportDTO>> GetDailyReportByIdAsync(int dailyReportId)
        {
            string appUserId = _userService.GetCurrentUserId();
            var dailyReport = await _mediator.Send(new GetDailyReportByIdQuery(dailyReportId, appUserId));

            return new Response<DailyReportDTO>(dailyReport, Result.Success());
        }

        public async Task<Response<GetDailyReportsResponseModel>> GetDailyReportsAsync(int skip, int take)
        {
            string appUserId = _userService.GetCurrentUserId();

            var dailyReports = await _mediator.Send(new GetDailyReportsQuery(skip, take, appUserId));
            int dailyReportsCount = await _mediator.Send(new GetDailyReportsCountQuery(appUserId));
            var getDailyReportsModel = new GetDailyReportsResponseModel(dailyReports, dailyReportsCount);

            return new Response<GetDailyReportsResponseModel>(getDailyReportsModel, Result.Success());
        }

        public async Task<Response<DailyReportDTO>> GetLastDailyReport()
        {
            string appUserId = _userService.GetCurrentUserId();
            var dailyReport = await _mediator.Send(new GetLastDailyReportQuery(appUserId));

            return new Response<DailyReportDTO>(dailyReport, Result.Success());
        }
    }
}
