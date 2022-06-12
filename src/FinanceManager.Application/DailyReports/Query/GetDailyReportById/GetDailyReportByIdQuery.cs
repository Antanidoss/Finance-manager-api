using FinanceManager.Application.Common.DTO;
using MediatR;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReportById
{
    public class GetDailyReportByIdQuery : IRequest<DailyReportDTO>
    {
        public readonly int DailyReportId;

        public readonly string AppUserId;

        public GetDailyReportByIdQuery(int dailyReportId, string appUserId)
        {
            DailyReportId = dailyReportId;
            AppUserId = appUserId;
        }
    }
}
