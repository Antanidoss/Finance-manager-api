using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Common.DTO
{
    public class DailyReportDTO
    {
        public string Id { get; set; }
        public int ReportsCount { get; set; }
        public string TimeOfCreate { get; set; }
        public IEnumerable<ReportDTO> Reports { get; set; }
    }
}
