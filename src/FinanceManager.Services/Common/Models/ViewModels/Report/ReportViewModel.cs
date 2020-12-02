using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels.Report
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public decimal AmountSpent { get; set; }
        public string DescriptionsOfExpenses { get; set; }
        public string TimeOfCreate { get; set; }
    }
}
