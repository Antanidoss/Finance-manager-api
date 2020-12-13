using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Domain.Entities
{
    public class DailyReport
    {
        public int Id { get; set; }
        public ICollection<Report> Reports { get; set; }
        public DateTime TimeOfCreate { get; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public DailyReport()
        {
            Reports = new List<Report>();
        }
        public DailyReport(string appUserId, ICollection<Report> reports = null)
        {
            TimeOfCreate = DateTime.Today;
            AppUserId = appUserId;
            Reports = reports != null ? reports : new List<Report>();
        }
    }
}
