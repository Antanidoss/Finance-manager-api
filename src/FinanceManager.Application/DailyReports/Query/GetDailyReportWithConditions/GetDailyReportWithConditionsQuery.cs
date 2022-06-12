﻿using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Linq.Expressions;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReportWithConditions
{
    public class GetDailyReportWithConditionsQuery : IRequest<DailyReport>
    {
        public readonly string AppUserId;

        public readonly Expression<Func<DailyReport, bool>> Conditions;

        public GetDailyReportWithConditionsQuery(string appUserId, Expression<Func<DailyReport, bool>> conditions)
        {
            AppUserId = appUserId;
            Conditions = conditions;
        }
    }
}
