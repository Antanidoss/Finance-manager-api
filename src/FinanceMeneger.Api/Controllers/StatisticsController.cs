using FinanceManager.Api.Attributes;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("get/month/{year}/{monthNumber}")]
        public async Task<Response<MonthlyStatistics>> GetReportsMonthlyStatistics(int year, int monthNumber)
        {
            return await _statisticsService.GetReportsMonthlyStatistics(year, monthNumber);
        }
    }
}
