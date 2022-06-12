using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReports
{
    public class GetDailyReportsWithConditionsQuery : IRequest<IEnumerable<DailyReport>>
    {
        public readonly string AppUserId;

        public readonly Func<DailyReport, bool> Conditions;

        public readonly int Skip;

        public readonly int Take;

        public GetDailyReportsWithConditionsQuery(int skip, int take, string appUserId, Func<DailyReport, bool> conditions)
        {
            AppUserId = appUserId;
            Conditions = conditions;
            Skip = skip;
            Take = take;
        }
    }
}
