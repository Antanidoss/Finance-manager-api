using FinanceManager.Application.Common.DTO;
using MediatR;

namespace FinanceManager.Application.Reports.Queries.GetReportById
{
    public class GetReportByIdQuery : IRequest<ReportDTO>
    {
        public readonly int ReportId;

        public readonly string AppUserId;

        public GetReportByIdQuery(int reportId, string appUserId)
        {
            ReportId = reportId;
            AppUserId = appUserId;
        }
    }
}
