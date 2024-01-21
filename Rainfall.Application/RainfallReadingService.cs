using Rainfall.Application.Models;

namespace Rainfall.Application
{
    public interface IRainfallReadingService
    {
        Task<List<RainfallReading>> GetRainfallReadingsAsync(string stationId, int count, CancellationToken cancelationToken = default);
    }

    public class RainfallReadingService : IRainfallReadingService
    {
        private readonly IGovRainfallReadingsClient _rainfallReadingsClient;

        public RainfallReadingService(IGovRainfallReadingsClient rainfallReadingsClient)
        {
            _rainfallReadingsClient = rainfallReadingsClient;
        }

        public async Task<List<RainfallReading>> GetRainfallReadingsAsync(string stationId, int count, CancellationToken cancelationToken = default)
        {
            var govRainfallReading = await _rainfallReadingsClient.GetRainfallReadingsAsync(stationId, count, cancelationToken);
            var rainfallReading = new List<RainfallReading>();

            foreach(var govReading in govRainfallReading.Items)
            {
                rainfallReading.Add(new RainfallReading()
                {
                    AmountMeasured = govReading.Value,
                    DateMeasured = govReading.DateTime
                });
            }

            return rainfallReading;
        }
    }
}
