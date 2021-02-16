using FinanceManager.Application.Common.Models;
using FinanceManager.Application.DailyReports.Query.GetDailyReports;
using FinanceManager.Application.DailyReports.Query.GetDailyReportsCount;
using FinanceManager.Application.DailyReports.Query.GetDailyReportWithConditions;
using FinanceManager.Application.Reports.Queries.GetReports;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userService;

        public StatisticsService(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        public async Task<Response<MonthlyStatistics>> GetReportsMonthlyStatistics(int year, int monthNumber)
        {
            string appUserId = _userService.GetCurrentUserId();
            int dailyReportCount = await _mediator.Send(new GetDailyReportsCountQuery(appUserId));
            var dailyReports = await _mediator.Send(new GetDailyReportsWithConditionsQuery(0, dailyReportCount, appUserId,
                (d) => d.TimeOfCreate.Month == monthNumber && d.TimeOfCreate.Year == year));

            if (dailyReports == null)
            {
                return new Response<MonthlyStatistics>(null, Result.Failure(new string[] { "" }));
            }

            decimal amountSpentPerMonth = 0;
            foreach (var dailyReport in dailyReports)
            {
                amountSpentPerMonth += dailyReport.Reports.Sum(r => r.AmountSpent);
            }

            var monthlyStatistics = new MonthlyStatistics(
                year: year,
                monthNumber: monthNumber,
                amountSpentPerMonth: amountSpentPerMonth, 
                numberOfReportsPerMonth: dailyReports.Select(d => d.Reports).Count());

            return new Response<MonthlyStatistics>(monthlyStatistics, Result.Success());
        }
    }
}
