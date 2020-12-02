using FinanceManager.Services.Common.Models.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels.DailyReport
{
    public class DailyReportViewModel
    {
        public string Id { get; set; }
        public ReportViewModel[] Reports { get; set; }
        public string TimeOfCreate { get; set; }
    }
}
