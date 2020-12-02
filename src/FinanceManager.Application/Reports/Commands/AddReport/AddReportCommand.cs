using FinanceManager.Application.Common.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Reports.Commands.AddReport
{
    public class AddReportCommand : IRequest<Result>
    {
        public readonly decimal AmountSpent;

        public readonly string DescriptionsOfExpenses;

        public readonly string AppUserId;
        public AddReportCommand(decimal amountSpent, string descriptionsOfExpenses, string appUserId)
        {
            AmountSpent = amountSpent;
            DescriptionsOfExpenses = descriptionsOfExpenses;
            AppUserId = appUserId;
        }
    }
}
