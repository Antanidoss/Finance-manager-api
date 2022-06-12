using MediatR;

namespace FinanceManager.Application.Reports.Queries.GetReportCount
{
    public class GetReportCountQuery : IRequest<int>
    {
        public readonly int DailyReportId;

        public GetReportCountQuery(int dailyReportId)
        {
            DailyReportId = dailyReportId;
        }
    }
}
