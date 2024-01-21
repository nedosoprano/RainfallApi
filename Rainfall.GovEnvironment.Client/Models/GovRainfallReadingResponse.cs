namespace Rainfall.Application.Models
{
    /// <summary>
    /// The rainfall reading responce scheme from the UK Department for Environment Food & Rural Affairs API.
    /// </summary>
    public class GovRainfallReadingResponse
    {
        public string? Context { get; set; }
        public GovRainfallReadingMeta? Meta { get; set; }
        public IEnumerable<GovRainfallReading>? Items { get; set; }
    }
}
