using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Reports.Commands.RemoveReport
{
    public class RemoveReportCommand : IRequest
    {
        public int ReportId { get; }
        public RemoveReportCommand(int reportId)
        {
            ReportId = reportId;
        }       
    }
}
