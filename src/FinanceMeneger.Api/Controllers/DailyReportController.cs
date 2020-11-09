using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.DailyReports.Query.GetDailyReportById;
using FinanceManager.Application.DailyReports.Query.GetDailyReports;
using FinanceManager.Application.DailyReports.Query.GetLastDailyReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<DailyReportDTO> GetDailyReportById(int dailyReportId)
        {
            return await _mediator.Send(new GetDailyReportByIdQuery(dailyReportId));
        }

        [HttpGet("get/{skip}&{take}")]
        public async Task<IEnumerable<DailyReportDTO>> GetDailyReports(int skip, int take)
        {
            return await _mediator.Send(new GetDailyReportsQuery(skip, take));
        }

        [HttpGet("getLast")]
        public async Task<DailyReportDTO> GetLastDailyReport(GetLastDailyReportQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
