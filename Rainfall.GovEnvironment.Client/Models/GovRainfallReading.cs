namespace Rainfall.Application.Models
{
    /// <summary>
    /// The rainfall reading by the UK Department for Environment Food & Rural Affairs scheme.
    /// </summary>
    public class GovRainfallReading
    {
        public string? Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Measure { get; set; }
        public decimal Value { get; set; }
    }
}
