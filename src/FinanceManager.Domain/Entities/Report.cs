using System;

namespace FinanceManager.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public decimal AmountSpent { get; set; }
        public string DescriptionsOfExpenses { get; set; }
        public DailyReport DailyReport { get; set; }
        public int DailyReportId { get; set; }
        public DateTime TimeOfCreate { get; set; }

        public Report() { }                

        public Report(decimal amountSpent, string descriptionsOfExpenses)
        {
            AmountSpent = amountSpent;
            DescriptionsOfExpenses = descriptionsOfExpenses;
            TimeOfCreate = DateTime.Now;
            DailyReport = new DailyReport();
        }
    }
}
