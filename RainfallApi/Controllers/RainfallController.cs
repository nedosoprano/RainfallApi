using Microsoft.AspNetCore.Mvc;
using Rainfall.Application;
using Rainfall.Application.Exceptions;
using Rainfall.Application.Models;
using RainfallApi.Exceptions;
using RainfallApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace RainfallApi.Controllers
{
    [ApiController]
    [Route("")]
    [Produces("application/json")]
    [SwaggerTag("Operations relating to rainfall")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallReadingService _rainfallService;

        public RainfallController(IRainfallReadingService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        /// <summary>
        /// Get rainfall readings by station Id.
        /// </summary>
        /// <remarks>Retrieve the latest readings for the specified stationId</remarks>
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified stationId</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("/rainfall/id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
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

        private static void ValidateRequest(string stationId, int count)
        {
            if (string.IsNullOrWhiteSpace(stationId))
                throw new InvalidRequestPropertyException(nameof(stationId), "The property can not be null or empty.");

            if (count < 1 || count > 100)
                throw new InvalidRequestPropertyException(nameof(count), "The property can not be less than 1 and more than 100.");
        }
    }
}
