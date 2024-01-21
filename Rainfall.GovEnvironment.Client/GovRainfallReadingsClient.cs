using Newtonsoft.Json;
using Rainfall.Application.Models;

namespace Rainfall.Application
{
    /// <summary>
    /// Interface for the Government Rainfall Readings Client, which makes requests to the UK Department for Environment Food & Rural Affairs API.
    /// </summary>
    public interface IGovRainfallReadingsClient
    {
        Task<GovRainfallReadingResponse> GetRainfallReadingsAsync(string stationId, int count, CancellationToken cancelationToken = default);
    }

    /// <summary>
    /// The client which makes requests to the UK Department for Environment Food & Rural Affairs API.
    /// </summary>
    public class GovRainfallReadingsClient : IGovRainfallReadingsClient
    {
        private readonly HttpClient _httpClient;
        private const string RainfallReadingsRoute = "/flood-monitoring/id/stations/{0}/readings?parameter=rainfall&_limit={1}";

        public GovRainfallReadingsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GovRainfallReadingResponse> GetRainfallReadingsAsync(string stationId, int count, CancellationToken cancelationToken = default)
        {
            var requestRoute = string.Format(RainfallReadingsRoute, stationId, count);

            var responce = await _httpClient.GetAsync(requestRoute, cancelationToken);
            var content = await responce.Content.ReadAsStringAsync(cancelationToken);

            //TODO: add error handling

            return JsonConvert.DeserializeObject<GovRainfallReadingResponse>(content);
        }
    }
}
