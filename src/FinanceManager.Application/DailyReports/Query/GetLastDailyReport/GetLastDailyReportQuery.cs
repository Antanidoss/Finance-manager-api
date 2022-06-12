using FinanceManager.Application.Common.DTO;
using MediatR;

namespace FinanceManager.Application.DailyReports.Query.GetLastDailyReport
{
    public class GetLastDailyReportQuery : IRequest<DailyReportDTO>
    {
        public string AppUserId { get; set; }

        public GetLastDailyReportQuery(string appUser)
        {
            AppUserId = appUser;
        }
    }
}
