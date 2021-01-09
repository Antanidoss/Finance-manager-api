using FinanceManager.Application.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Reports.Queries.GetReports
{
    public class GetReportsQuery : IRequest<IEnumerable<ReportDTO>>
    {
        public readonly int Skip;

        public readonly int Take;

        public readonly string AppUserId;

        public readonly int DailyReportId;

        public GetReportsQuery(int skip, int take, string appUserId, int dailyReportId)
        {
            Skip = skip;
            Take = take;
            AppUserId = appUserId;
            DailyReportId = dailyReportId;
        }
    }
}
