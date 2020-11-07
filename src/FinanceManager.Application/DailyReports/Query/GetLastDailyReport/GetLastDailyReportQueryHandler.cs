using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.DailyReports.Query.GetLastDailyReport
{
    public class GetLastDailyReportQueryHandler : IRequestHandler<GetLastDailyReportQuery, DailyReportDTO>
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        private readonly IMapper _mapper;

        public GetLastDailyReportQueryHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }

        public async Task<DailyReportDTO> Handle(GetLastDailyReportQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DailyReportDTO>(await _dailyReportRepository.GetLastDailyReportAsync(request.AppUserId));
        }
    }
}
