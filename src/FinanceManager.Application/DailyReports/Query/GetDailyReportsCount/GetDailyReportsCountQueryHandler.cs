using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReportsCount
{
    public class GetDailyReportsCountQueryHandler : IRequestHandler<GetDailyReportsCountQuery, int>
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        public GetDailyReportsCountQueryHandler(IDailyReportRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<int> Handle(GetDailyReportsCountQuery request, CancellationToken cancellationToken)
        {
            return await _dailyReportRepository.GetDailyReportCount(request.AppUserId);
        }
    }
}
