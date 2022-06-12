using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using MediatR;

namespace FinanceManager.Application.Reports.Commands.UpdateReport
{
    public class UpdateReportCommand : IRequest<Result>
    {
        public readonly ReportDTO Report;

        public readonly string AppUserId;
        public UpdateReportCommand(ReportDTO report, string appUserId)
        {
            Report = report;
            AppUserId = appUserId;
        }
    }
}
