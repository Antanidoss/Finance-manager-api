using FinanceManager.Application.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Reports.Queries.GetReports
{
    public class GetReportsQuery : IRequest<IEnumerable<ReportDTO>>
    {
        public int Skip { get; }
        public int Take { get; }
        public string AppUserId { get; set; }
        public GetReportsQuery(int skip, int take, string appUserId)
        {
            Skip = skip;
            Take = take;
            AppUserId = appUserId;
        }
    }
}
