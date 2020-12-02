using FinanceManager.Application.Common.Exceptions;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Commands.RemoveReport
{
    public class RemoveReportCommandHandler : IRequestHandler<RemoveReportCommand, Result>
    {
        private readonly IReportRepository _reportRepository;

        public RemoveReportCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Result> Handle(RemoveReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.GetReportByIdAsync(request.ReportId);

            if (report == null)
            {
                throw new NotFoundException(nameof(Report), request.ReportId);
            }
            if (report.DailyReport.AppUserId != request.AppUserId)
            {
                return Result.Failure(new string[] { "Неверный id отчета" });
            }

            await _reportRepository.RemoveReportAsync(report);

            return Result.Success(); 
        }
    }
}
