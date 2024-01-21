using Rainfall.Application.Models;

namespace RainfallApi.Models
{
    /// <summary>
    /// The Rainfall Reading response.
    /// </summary>
    public class RainfallReadingResponse
    {
        public IEnumerable<RainfallReading> RainfallReadings { get; set; }

        public RainfallReadingResponse(IEnumerable<RainfallReading> rainfallReadings)
        {
            RainfallReadings = rainfallReadings;
        }
    }
}
