﻿using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Models.ViewModels.Report;
using System.Collections.Generic;

namespace FinanceManager.Services.Common.Models.ViewModels.Report
{
    public class GetReportsResponseModel
    {
        public IEnumerable<ReportDTO> Reports { get; }
        public int TotalReportCount { get; }

        public GetReportsResponseModel(IEnumerable<ReportDTO> reports, int totalReportCount)
        {
            Reports = reports;
            TotalReportCount = totalReportCount;
        }
    }
}
