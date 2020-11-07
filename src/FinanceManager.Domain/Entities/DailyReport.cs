using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Domain.Entities
{
    public class DailyReport
    {
        public int Id { get; set; }
        public IEnumerable<Report> Reports { get; set; }
        public DateTime TimeOfCreate { get; }
        public DailyReport()
        {
            TimeOfCreate = DateTime.Now;
            Reports = new List<Report>();
        }
    }
}
