using System.Threading.Tasks;
using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels.Report;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [System.Web.Http.Authorize]
    public class ReportController : ApiController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("add")]
        public async Task<Result> AddReport([FromQuery]ReportCreateModel model)
        {
            return await _reportService.AddReportAsync(model);
        }

        [HttpGet("get/{reportId}")]
        public async Task<ReportViewModel> GetReportById(int reportId)
        {
            return await _reportService.GetReportByIdAsync(reportId);
        }

        [HttpDelete("remove/{reportId}")]
        public async Task<Result> RemoveReport(int reportId)
        {
            return await _reportService.RemoveReportAsync(reportId);
        }

        [HttpPut("update")]
        public async Task<Result> UpdateReport([FromQuery]ReportUpdateModel model)
        {
            return await _reportService.UpdatereportAsync(model);
        }

        [HttpGet("get/{skip}&{take}&{dailyReportId}")]
        public async Task<GetReportsResponceModel> GetReports(int skip, int take, int dailyReportId)
        {
            return await _reportService.GetReportsAsync(skip, take, dailyReportId);
        }
    }
}