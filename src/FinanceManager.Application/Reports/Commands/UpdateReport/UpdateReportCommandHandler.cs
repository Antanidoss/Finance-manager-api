using FinanceManager.Application.Common.Exceptions;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Reports.Commands.UpdateReport
{
    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand>
    {
        private readonly IReportRepository _reportRepository;

        public UpdateReportCommandHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Unit> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.GetReportByIdAsync(request.ReportId);

            if(report == null)
            {
                throw new NotFoundException(nameof(report), request.ReportId);
            }

            await _reportRepository.UpdateReportAsync(new Report(request.AmountSpent, request.DescriptionsOfExpenses));

            return Unit.Value;
        }
    }
}
