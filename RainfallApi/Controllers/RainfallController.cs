using Microsoft.AspNetCore.Mvc;
using Rainfall.Application;
using Rainfall.Application.Models;

namespace RainfallApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallReadingService _rainfallService;
        private readonly ILogger<RainfallController> _logger;

        public RainfallController(IRainfallReadingService rainfallService, ILogger<RainfallController> logger)
        {
            _rainfallService = rainfallService;
            _logger = logger;
        }

        [HttpGet("/id/{stationId}/readings")]
        public async Task<IEnumerable<RainfallReading>> GetRainfallReadingsAsync(string stationId, [FromQuery] int count)
        {
            return await _rainfallService.GetRainfallReadingsAsync(stationId, count);
        }
    }
}
