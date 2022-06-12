using FinanceManager.Api.Attributes;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DailyReportController : ApiController
    {
        private readonly IDailyReportService _dailyReportService;

        public DailyReportController(IDailyReportService dailyReportService)
        {
            _dailyReportService = dailyReportService;
        }

        [HttpGet("get/{dailyReportId}")]
        public async Task<Response<DailyReportDTO>> GetDailyReportById(int dailyReportId)
        {
            return await _dailyReportService.GetDailyReportByIdAsync(dailyReportId);
        }

        [HttpGet("get/{skip}&{take}")]
        public async Task<Response<GetDailyReportsResponseModel>> GetDailyReports(int skip, int take)
        {
            return await _dailyReportService.GetDailyReportsAsync(skip, take);
        }

        [HttpGet("getLast")]
        public async Task<Response<DailyReportDTO>> GetLastDailyReport()
        {
            return await _dailyReportService.GetLastDailyReport();
        }
    }
}