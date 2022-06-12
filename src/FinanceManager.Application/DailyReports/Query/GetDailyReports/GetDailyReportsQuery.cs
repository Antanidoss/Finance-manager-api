using FinanceManager.Application.Common.DTO;
using MediatR;
using System.Collections.Generic;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReports
{
    public class GetDailyReportsQuery : IRequest<IEnumerable<DailyReportDTO>>
    {
        public readonly int Skip;

        public readonly int Take;

        public readonly string AppUserId; 

        public GetDailyReportsQuery(int skip, int take, string appUserId)
        {
            Skip = skip;
            Take = take;
            AppUserId = appUserId;
        }
    }
}
