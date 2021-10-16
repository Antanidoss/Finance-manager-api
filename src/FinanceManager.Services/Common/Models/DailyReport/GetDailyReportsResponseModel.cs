using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels.DailyReport
{
    public class GetDailyReportsResponseModel
    {
        public IEnumerable<DailyReportDTO> DailyReports { get; }
        public int TotalDailyReportCount { get; }
        public GetDailyReportsResponseModel(IEnumerable<DailyReportDTO> dailyReports, int totalDailyReportCount)
        {
            DailyReports = dailyReports;
            TotalDailyReportCount = totalDailyReportCount;
        }
    }
}
