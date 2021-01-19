using AutoMapper;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.DailyReports.Query.GetDailyReportById;
using FinanceManager.Application.DailyReports.Query.GetDailyReports;
using FinanceManager.Application.DailyReports.Query.GetDailyReportsCount;
using FinanceManager.Application.DailyReports.Query.GetLastDailyReport;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        private readonly IUserService _userService;
        public DailyReportService(IMapper mapper, IMediator mediator, IUserService userService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _userService = userService;
        }
        public async Task<Response<DailyReportViewModel>> GetDailyReportByIdAsync(int dailyReportId)
        {
            string appUserId = _userService.GetCurrentUserId();
            var dailyReport = await _mediator.Send(new GetDailyReportByIdQuery(dailyReportId, appUserId));

            return new Response<DailyReportViewModel>(_mapper.Map<DailyReportViewModel>(dailyReport), Result.Success());
        }

        public async Task<Response<GetDailyReportsResponseModel>> GetDailyReportsAsync(int skip, int take)
        {
            string appUserId = _userService.GetCurrentUserId();

            var dailyReports = await _mediator.Send(new GetDailyReportsQuery(skip, take, appUserId));
            int dailyReportsCount = await _mediator.Send(new GetDailyReportsCountQuery(appUserId));
            var getDailyReportsModel = new GetDailyReportsResponseModel(_mapper.Map<IEnumerable<DailyReportViewModel>>(dailyReports), 
                dailyReportsCount);

            return new Response<GetDailyReportsResponseModel>(getDailyReportsModel, Result.Success());
        }

        public async Task<Response<DailyReportViewModel>> GetLastDailyReport()
        {
            string appUserId = _userService.GetCurrentUserId();
            var dailyReport = await _mediator.Send(new GetLastDailyReportQuery(appUserId));

            return new Response<DailyReportViewModel>(_mapper.Map<DailyReportViewModel>(dailyReport), Result.Success());
        }
    }
}
