using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Commands.AddReport
{
    public class AddReportCommnadHandler : IRequestHandler<AddReportCommand, Result>
    {
        private readonly IReportRepository _reportRepository;

        private readonly IDailyReportRepository _dailyReportRepository;

        public AddReportCommnadHandler(IReportRepository reportRepository, IDailyReportRepository dailyReportRepository)
        {
            _reportRepository = reportRepository;
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<Result> Handle(AddReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report(request.AmountSpent, request.DescriptionsOfExpenses);

            var lastDailyReport = await _dailyReportRepository.GetLastDailyReportAsync(request.AppUserId);
        
            report.DailyReport = lastDailyReport != null && lastDailyReport.TimeOfCreate.CompareTo(DateTime.Today) == 0
                ? lastDailyReport
                : report.DailyReport = new DailyReport() { AppUserId = request.AppUserId };

            await _reportRepository.AddReportAsync(report);

            return Result.Success();
        }
    }
}
