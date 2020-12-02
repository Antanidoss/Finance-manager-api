using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels.DailyReport
{
    public class GetDailyReportsResponceModel
    {
        public IEnumerable<DailyReportViewModel> DailyReports { get; }
        public int TotalDailyReportCount { get; }
        public GetDailyReportsResponceModel(IEnumerable<DailyReportViewModel> dailyReports, int totalDailyReportCount)
        {
            DailyReports = dailyReports;
            TotalDailyReportCount = totalDailyReportCount;
        }
    }
}
