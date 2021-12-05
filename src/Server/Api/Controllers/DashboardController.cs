using System.Threading;
using System.Threading.Tasks;
using Application.Dashboard.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Requests.Dashboard;

namespace Api.Controllers
{
    [Route("dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly StatisticsRetriever _statisticsRetriever;

        public DashboardController(StatisticsRetriever statisticsRetriever)
        {
            _statisticsRetriever = statisticsRetriever;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DashboardInformationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDashboardStatistics(CancellationToken cancellation)
        {
            return Ok(await _statisticsRetriever.GetDashboardStatistics(cancellation));
        }
    }
}
