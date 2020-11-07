using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Common.DTO
{
    public class DailyReportDTO
    {
        public int Id { get; set; }
        public List<ReportDTO> Reports { get; set; }
        public string TimeOfCreate { get; }
    }
}
