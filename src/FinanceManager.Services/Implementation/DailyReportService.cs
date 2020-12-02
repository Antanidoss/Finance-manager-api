using AutoMapper;
using FinanceManager.Application.DailyReports.Query.GetDailyReportById;
using FinanceManager.Application.DailyReports.Query.GetDailyReports;
using FinanceManager.Application.DailyReports.Query.GetDailyReportsCount;
using FinanceManager.Application.DailyReports.Query.GetLastDailyReport;
using FinanceManager.Services.Common.Interfaces;
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
        public async Task<DailyReportViewModel> GetDailyReportByIdAsync(int dailyReportId)
        {
            string appUserId = _userService.GetCurrentUserId();

            return _mapper.Map<DailyReportViewModel>(await _mediator.Send(new GetDailyReportByIdQuery(dailyReportId, appUserId)));
        }

        public async Task<GetDailyReportsResponceModel> GetDailyReportsAsync(int skip, int take)
        {
            string appUserId = _userService.GetCurrentUserId();

            var dailyReports = await _mediator.Send(new GetDailyReportsQuery(skip, take, appUserId));
            int dailyReportsCount = await _mediator.Send(new GetDailyReportsCountQuery(appUserId));

            return new GetDailyReportsResponceModel(_mapper.Map<IEnumerable<DailyReportViewModel>>(dailyReports), dailyReportsCount);
        }

        public async Task<DailyReportViewModel> GetLastDailyReport()
        {
            string appUserId = _userService.GetCurrentUserId();

            return _mapper.Map<DailyReportViewModel>(await _mediator.Send(new GetLastDailyReportQuery(appUserId)));
        }
    }
}
