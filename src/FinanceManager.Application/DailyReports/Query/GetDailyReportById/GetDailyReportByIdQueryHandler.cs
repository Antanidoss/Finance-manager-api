using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Exceptions;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.DailyReports.Query.GetDailyReportById
{
    public class GetDailyReportByIdQueryHandler : IRequestHandler<GetDailyReportByIdQuery, DailyReportDTO>
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        private readonly IMapper _mapper;

        public GetDailyReportByIdQueryHandler(IDailyReportRepository dailyReportRepository, IMapper mapper)
        {
            _dailyReportRepository = dailyReportRepository;
            _mapper = mapper;
        }

        public async Task<DailyReportDTO> Handle(GetDailyReportByIdQuery request, CancellationToken cancellationToken)
        {
            var dailyReport =  await _dailyReportRepository.GetDailyReportByIdAsync(request.DailyReportId);

            if(dailyReport == null)
            {
                throw new NotFoundException(nameof(dailyReport), request.DailyReportId);
            }

            return _mapper.Map<DailyReportDTO>(dailyReport);
        }
    }
}
