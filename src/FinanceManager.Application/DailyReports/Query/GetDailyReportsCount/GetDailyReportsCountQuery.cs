using MediatR;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReportsCount
{
    public class GetDailyReportsCountQuery : IRequest<int>
    {
        public readonly string AppUserId;

        public GetDailyReportsCountQuery(string appUserId)
        {
            AppUserId = appUserId;
        }
    }
}
