using FinanceManager.Application.Common.Exceptions;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Commands.RemoveReport
{
    public class RemoveReportCommandHandler : IRequestHandler<RemoveReportCommand>
    {
        private readonly IReportRepository _reportRepository;

        public RemoveReportCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Unit> Handle(RemoveReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.GetReportByIdAsync(request.ReportId);

            if(report == null)
            {
                throw new NotFoundException(nameof(Report), request.ReportId);
            }

            await _reportRepository.RemoveReportAsync(report);

            return Unit.Value; 
        }
    }
}
