using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Queries.GetReports
{
    public class GetReportsWihtConditionsQueryHandler : IRequestHandler<GetReportsWihtConditionsQuery, IEnumerable<Report>>
    {
        private readonly IReportRepository _reportRepository;

        public GetReportsWihtConditionsQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<IEnumerable<Report>> Handle(GetReportsWihtConditionsQuery request, CancellationToken cancellationToken)
        {
            return await _reportRepository.GetReportsAsync(request.Skip, request.Take, request.DailyReportId, request.Conditions);
        }
    }
}
