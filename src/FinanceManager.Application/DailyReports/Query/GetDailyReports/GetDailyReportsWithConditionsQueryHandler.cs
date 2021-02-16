using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReports
{
    public class GetDailyReportsWithConditionsQueryHandler : IRequestHandler<GetDailyReportsWithConditionsQuery, IEnumerable<DailyReport>>
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        public GetDailyReportsWithConditionsQueryHandler(IDailyReportRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<IEnumerable<DailyReport>> Handle(GetDailyReportsWithConditionsQuery request, CancellationToken cancellationToken)
        {            
            return await _dailyReportRepository.GetDailyReportsAsync(request.Skip, request.Take, request.AppUserId, request.Conditions);
        }
    }
}
