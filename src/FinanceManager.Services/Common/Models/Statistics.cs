namespace FinanceManager.Services.Common.Models
{
    public class MonthlyStatistics
    {
        public int Year { get; set; }
        public int MonthNumber { get; set; }
        public decimal AmountSpentPerMonth { get; set; }
        public int NumberOfReportsPerMonth { get; set; }

        public MonthlyStatistics(int year, int monthNumber, decimal amountSpentPerMonth, int numberOfReportsPerMonth)
        {
            Year = year;
            MonthNumber = monthNumber;
            AmountSpentPerMonth = amountSpentPerMonth;
            NumberOfReportsPerMonth = numberOfReportsPerMonth;
        }
    }
}
