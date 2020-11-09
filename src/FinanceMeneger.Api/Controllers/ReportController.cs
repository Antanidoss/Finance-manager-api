﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Reports.Commands.AddReport;
using FinanceManager.Application.Reports.Commands.RemoveReport;
using FinanceManager.Application.Reports.Commands.UpdateReport;
using FinanceManager.Application.Reports.Queries.GetReportById;
using FinanceManager.Application.Reports.Queries.GetReports;
using FinanceManeger.Api.Models.CreateModel;
using FinanceManeger.Api.Models.UpdateModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task AddReport([FromQuery]ReportCreateModel model)
        {
            await _mediator.Send(new AddReportCommand(model.AmountSpent, model.DescriptionsOfExpenses, model.AppUserId));
        }

        [HttpGet("get/{id}")]
        public async Task<ReportDTO> GetReportById(int reportId)
        {
            return await _mediator.Send(new GetReportByIdQuery(reportId));
        }

        [HttpDelete("remove/{id}")]
        public async Task RemoveReport(int reportId)
        {
            await _mediator.Send(new RemoveReportCommand(reportId));
        }

        [HttpPut("update")]
        public async Task UpdateReport([FromQuery]ReportUpdateModel model)
        {
            await _mediator.Send(new UpdateReportCommand(model.AmountSpent, model.DescriptionsOfExpenses, model.ReportId));
        }

        [HttpGet("get/{skip}&{take}")]
        public async Task<IEnumerable<ReportDTO>> GetReports(int skip, int take)
        {
            return (await _mediator.Send(new GetReportsQuery(skip, take)));
        }
    }
}