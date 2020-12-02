using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
