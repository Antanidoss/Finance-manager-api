using FinanceManager.Application.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReportById
{
    public class GetDailyReportByIdQuery : IRequest<DailyReportDTO>
    {
        public int DailyReportId { get; }

        public GetDailyReportByIdQuery(int dailyReportId)
        {
            DailyReportId = dailyReportId;
        }
    }
}
