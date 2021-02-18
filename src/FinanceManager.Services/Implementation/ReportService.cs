using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.DailyReports.Query.GetDailyReportsCount;
using FinanceManager.Application.DailyReports.Query.GetDailyReportWithConditions;
using FinanceManager.Application.Reports.Commands.AddReport;
using FinanceManager.Application.Reports.Commands.RemoveReport;
using FinanceManager.Application.Reports.Commands.UpdateReport;
using FinanceManager.Application.Reports.Queries.GetReportById;
using FinanceManager.Application.Reports.Queries.GetReportCount;
using FinanceManager.Application.Reports.Queries.GetReports;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.Report;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userService;

        private readonly IMapper _mapper;
        public ReportService(IMediator mediator, IUserService userService, IMapper mapper)
        {
            _mediator = mediator;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Result> AddReportAsync(ReportCreateModel model)
        {
            string appUserId = _userService.GetCurrentUserId();

            return await _mediator.Send(new AddReportCommand(_mapper.Map<ReportDTO>(model), appUserId));
        }

        public async Task<Response<ReportDTO>> GetReportByIdAsync(int reportId)
        {
            string appUserId = _userService.GetCurrentUserId();
            var report = await _mediator.Send(new GetReportByIdQuery(reportId, appUserId));

            return new Response<ReportDTO>(report, Result.Success());           
        }

        public async Task<Response<GetReportsResponseModel>> GetReportsAsync(int skip, int take, int dailyReportId)
        {
            string appUserId = _userService.GetCurrentUserId();
            var reports = await _mediator.Send(new GetReportsQuery(skip, take, appUserId, dailyReportId));
            int reportsCount = await _mediator.Send(new GetReportCountQuery(dailyReportId));

            var getReportsResponseModel = new GetReportsResponseModel(reports, reportsCount);

            return new Response<GetReportsResponseModel>(getReportsResponseModel, Result.Success());
        }       

        public async Task<Result> RemoveReportAsync(int reportId)
        {
            string appUserId = _userService.GetCurrentUserId();

            return await _mediator.Send(new RemoveReportCommand(reportId, appUserId));
        }

        public async Task<Result> UpdatereportAsync(ReportUpdateModel model)
        {
            string appUserId = _userService.GetCurrentUserId();

            return await _mediator.Send(new UpdateReportCommand(_mapper.Map<ReportDTO>(model), appUserId));
        }
    }
}
