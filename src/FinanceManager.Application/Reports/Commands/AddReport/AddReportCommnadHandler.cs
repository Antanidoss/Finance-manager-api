using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Commands.AddReport
{
    public class AddReportCommnadHandler : IRequestHandler<AddReportCommand>
    {
        private readonly IReportRepository _reportRepository;

        private readonly IDailyReportRepository _dailyReportRepository;

        public AddReportCommnadHandler(IReportRepository reportRepository, IDailyReportRepository dailyReportRepository)
        {
            _reportRepository = reportRepository;
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<Unit> Handle(AddReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report(request.AmountSpent, request.DescriptionsOfExpenses);

            var lastDailyReport = await _dailyReportRepository.GetLastDailyReportAsync(request.AppUserId);

            if(lastDailyReport == null)
            {
                report.DailyReportId = lastDailyReport.Id;
            }

            await _reportRepository.AddReportAsync(report);

            return Unit.Value;
        }
    }
}
