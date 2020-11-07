using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Reports.Commands.AddReport
{
    public class AddReportCommand : IRequest
    {
        public decimal AmountSpent { get; }
        public string DescriptionsOfExpenses { get; }
        public string AppUserId { get; }
        public AddReportCommand(decimal amountSpent, string descriptionsOfExpenses, string appUserId)
        {
            AmountSpent = amountSpent;
            DescriptionsOfExpenses = descriptionsOfExpenses;
            AppUserId = appUserId;
        }
    }
}
