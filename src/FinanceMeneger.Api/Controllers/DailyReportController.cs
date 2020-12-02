using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [System.Web.Http.Authorize]
    public class DailyReportController : ApiController
    {
        private readonly IDailyReportService _dailyReportService;

        public DailyReportController(IDailyReportService dailyReportService)
        {
            _dailyReportService = dailyReportService;
        }

        [HttpGet("get/{dailyReportId}")]
        public async Task<DailyReportViewModel> GetDailyReportById(int dailyReportId)
        {
            return await _dailyReportService.GetDailyReportByIdAsync(dailyReportId);
        }

        [HttpGet("get/{skip}&{take}")]
        public async Task<GetDailyReportsResponceModel> GetDailyReports(int skip, int take)
        {
            return await _dailyReportService.GetDailyReportsAsync(skip, take);
        }

        [HttpGet("getLast")]
        public async Task<DailyReportViewModel> GetLastDailyReport()
        {
            return await _dailyReportService.GetLastDailyReport();
        }
    }
}
