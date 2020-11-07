using FinanceManager.Application.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReports
{
    public class GetDailyReportsQuery : IRequest<IEnumerable<DailyReportDTO>>
    {
        public int Skip { get; }
        public int Take { get; }
        public GetDailyReportsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
