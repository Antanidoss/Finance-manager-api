using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Queries.GetReportCount
{
    public class GetReportCountQueryHandler : IRequestHandler<GetReportCountQuery, int>
    {
        private readonly IReportRepository _reportRepository;

        public GetReportCountQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<int> Handle(GetReportCountQuery request, CancellationToken cancellationToken)
        {
            return await _reportRepository.GetReportCount(request.DailyReportId);
        }
    }
}
