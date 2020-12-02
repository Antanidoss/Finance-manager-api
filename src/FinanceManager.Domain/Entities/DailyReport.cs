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
            TimeOfCreate = DateTime.Today;
            Reports = new List<Report>();
        }
    }
}
