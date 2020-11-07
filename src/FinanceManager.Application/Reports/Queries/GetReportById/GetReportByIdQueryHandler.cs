using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Queries.GetReportById
{
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDTO>
    {
        private readonly IMapper _mapper;

        private readonly IReportRepository _reportRepository;

        public GetReportByIdQueryHandler(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<ReportDTO> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ReportDTO>(await _reportRepository.GetReportByIdAsync(request.ReportId));
        }
    }
}
