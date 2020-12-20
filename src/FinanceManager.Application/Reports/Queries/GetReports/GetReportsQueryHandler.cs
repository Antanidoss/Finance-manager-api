using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
            if(request.Skip < 0 && request.Take <= 0)
            {
                throw new ArgumentException("Invalid input parameters (skip), (take)");
            }

            var reports = await _reportRepository.GetReportsAsync(request.Skip, request.Take, (r) => 
            { 
                return r.DailyReportId == request.DailyReportId && r.DailyReport.AppUserId == request.AppUserId; 
            });

            return _mapper.Map<IEnumerable<ReportDTO>>(reports);
        }
    }
}
