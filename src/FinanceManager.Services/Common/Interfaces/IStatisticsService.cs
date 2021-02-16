using FinanceManager.Services.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IStatisticsService
    {
        Task<Response<MonthlyStatistics>> GetReportsMonthlyStatistics(int year, int monthNumber);
    }
}
