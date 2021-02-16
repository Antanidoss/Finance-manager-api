using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Reports.Queries.GetReports
{
    public class GetReportsWihtConditionsQuery : IRequest<IEnumerable<Report>>
    {
        public readonly int Skip;

        public readonly int Take;

        public readonly string AppUserId;

        public readonly int DailyReportId;

        public readonly Func<Report, bool> Conditions;

        public GetReportsWihtConditionsQuery(int skip, int take, string appUserId, int dailyReportId, Func<Report, bool> conditions)
        {
            Skip = skip;
            Take = take;
            AppUserId = appUserId;
            DailyReportId = dailyReportId;
            Conditions = conditions;
        }
    }
}
