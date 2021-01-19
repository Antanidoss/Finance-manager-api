using System;
using System.Collections.Generic;

namespace FinanceManager.Domain.Entities
{
    public class DailyReport
    {
        public int Id { get; set; }
        public IEnumerable<Report> Reports { get; set; }
        public DateTime TimeOfCreate { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public DailyReport()
        {
            Reports = new List<Report>();
        }
        public DailyReport(string appUserId)
        {
            AppUserId = appUserId;
            TimeOfCreate = DateTime.Today;
            Reports = new List<Report>();
        }
    }
}
