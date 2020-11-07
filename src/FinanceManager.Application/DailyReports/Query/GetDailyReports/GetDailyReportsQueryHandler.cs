using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReports
{
    public class GetDailyReportsQueryHandler : IRequestHandler<GetDailyReportsQuery, IEnumerable<DailyReportDTO>>
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        private readonly IMapper _mapper;
        public GetDailyReportsQueryHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DailyReportDTO>> Handle(GetDailyReportsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<DailyReportDTO>>(await _dailyReportRepository.GetDailyReportsAsync(request.Skip, request.Take));
        }
    }
}
