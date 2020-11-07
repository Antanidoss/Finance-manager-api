using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Reports.Commands.UpdateReport
{
    public class UpdateReportCommand : IRequest
    {
        public decimal AmountSpent { get; }
        public string DescriptionsOfExpenses { get; }
        public int ReportId { get; }

        public UpdateReportCommand(decimal amountSpent, string descriptionsOfExpenses, int reportId)
        {
            AmountSpent = amountSpent;
            DescriptionsOfExpenses = descriptionsOfExpenses;
            ReportId = reportId;
        }
    }
}
