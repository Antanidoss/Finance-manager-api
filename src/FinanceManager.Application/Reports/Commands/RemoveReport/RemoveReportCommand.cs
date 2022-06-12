using FinanceManager.Application.Common.Models;
using MediatR;

namespace FinanceManager.Application.Reports.Commands.RemoveReport
{
    public class RemoveReportCommand : IRequest<Result>
    {
        public int ReportId { get; }
        public string AppUserId { get; set; }
        public RemoveReportCommand(int reportId, string appUserId)
        {
            ReportId = reportId;
            AppUserId = appUserId;
        }
    }
}
