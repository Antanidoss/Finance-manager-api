using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using MediatR;

namespace FinanceManager.Application.Reports.Commands.AddReport
{
    public class AddReportCommand : IRequest<Result>
    {
        public readonly ReportDTO Report;

        public readonly string AppUserId;
        public AddReportCommand(ReportDTO report, string appUserId)
        {
            Report = report;
            AppUserId = appUserId;
        }
    }
}
