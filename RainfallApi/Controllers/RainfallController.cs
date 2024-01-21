using Microsoft.AspNetCore.Mvc;
using Rainfall.Application;
using Rainfall.Application.Exceptions;
using Rainfall.Application.Models;
using RainfallApi.Exceptions;
using RainfallApi.Models;

namespace RainfallApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallReadingService _rainfallService;

        public RainfallController(IRainfallReadingService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        [HttpGet("/id/{stationId}/readings")]
        public async Task<IActionResult> GetRainfallReadingsAsync(string stationId, [FromQuery] int count = 10)
        {
            IEnumerable<RainfallReading> rainfallReadings;

            try
            {
                ValidateRequest(stationId, count);

                rainfallReadings = await _rainfallService.GetRainfallReadingsAsync(stationId, count);
            }
            catch (InvalidRequestPropertyException ex)
            {
                return BadRequest(ex.ErrorDetail);
            }
            catch (RainfullReadingsEmptyException ex)
            {
                return NotFound(new ErrorDetail()
                {
                    PropertyName = nameof(stationId),
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(ex.Message));
            }

            return Ok(rainfallReadings);
        }

        private void ValidateRequest(string stationId, int count)
        {
            if (string.IsNullOrWhiteSpace(stationId))
                throw new InvalidRequestPropertyException(nameof(stationId), "The property can not be null or empty.");

            if (count < 1 || count > 100)
                throw new InvalidRequestPropertyException(nameof(count), "The property can not be less than 1 and more than 100.");
        }
    }
}
