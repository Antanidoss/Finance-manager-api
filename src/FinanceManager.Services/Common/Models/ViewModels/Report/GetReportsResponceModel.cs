using FinanceManager.Services.Common.Models.ViewModels.Report;
using System.Collections.Generic;

namespace FinanceManager.Services.Common.Models.ViewModels.Report
{
    public class GetReportsResponceModel
    {
        public IEnumerable<ReportViewModel> Reports { get; }
        public int TotalReportCount { get; }

        public GetReportsResponceModel(IEnumerable<ReportViewModel> reports, int totalReportCount)
        {
            Reports = reports;
            TotalReportCount = totalReportCount;
        }
    }
}
