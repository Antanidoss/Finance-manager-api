using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Common.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public decimal AmountSpent { get; set; }
        public string DescriptionsOfExpenses { get; set; }
        public string TimeOfCreate { get; }
    }
}
