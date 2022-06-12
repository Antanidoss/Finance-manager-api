using FinanceManager.Application.Common.Exceptions;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Commands.UpdateReport
{
    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, Result>
    {
        private readonly IReportRepository _reportRepository;

        public UpdateReportCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Result> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.GetReportByIdAsync(request.Report.Id);

            if (report == null)
                throw new NotFoundException(nameof(report), request.Report.Id);

            if (report.DailyReport.AppUserId != request.AppUserId)
                return Result.Failure(new string[] { "Неверный id отчета" });

            var updateReport = new Report(request.Report.AmountSpent, request.Report.DescriptionsOfExpenses) { Id = request.Report.Id };
            await _reportRepository.UpdateReportAsync(updateReport);

            return Result.Success();
        }
    }
}
