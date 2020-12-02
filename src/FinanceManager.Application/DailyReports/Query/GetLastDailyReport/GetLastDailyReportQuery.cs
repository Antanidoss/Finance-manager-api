using FinanceManager.Application.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
