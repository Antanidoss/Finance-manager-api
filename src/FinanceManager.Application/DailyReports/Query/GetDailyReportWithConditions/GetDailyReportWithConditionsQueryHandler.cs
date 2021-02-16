using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReportWithConditions
{
    public class GetDailyReportWithConditionsQueryHandler : IRequestHandler<GetDailyReportWithConditionsQuery, DailyReport>
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        public GetDailyReportWithConditionsQueryHandler(IDailyReportRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<DailyReport> Handle(GetDailyReportWithConditionsQuery request, CancellationToken cancellationToken)
        {

            return await _dailyReportRepository.GetDailyReport(request.AppUserId, request.Conditions);
        }
    }
}
