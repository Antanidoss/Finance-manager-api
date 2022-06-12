using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Queries.GetReports
{
    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, IEnumerable<ReportDTO>>
    {
        private readonly IMapper _mapper;

        private readonly IReportRepository _reportRepository;
        public GetReportsQueryHandler(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<IEnumerable<ReportDTO>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportRepository.GetReportsAsync(request.Skip, request.Take, request.DailyReportId);

            return _mapper.Map<IEnumerable<ReportDTO>>(reports);
        }
    }
}
