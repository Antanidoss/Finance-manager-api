﻿using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IReportRepository
    {
        Task AddReportAsync(Report report);
        Task<Report> GetReportByIdAsync(int reportId);
        Task<IEnumerable<Report>> GetReportsAsync(int skip, int take);
        Task<IEnumerable<Report>> GetReportsAsync(int skip, int take, Func<Report, bool> func);
        Task RemoveReportAsync(Report report);
        Task UpdateReportAsync(Report report);
    }
}