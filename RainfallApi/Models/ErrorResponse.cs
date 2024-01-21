namespace RainfallApi.Models
{
    /// <summary>
    /// An error object returned for failed requests.
    /// </summary>
    public class ErrorResponse
    {
        public string? Message { get; set; }

        public IEnumerable<ErrorDetail>? Detail { get; set; }

        public ErrorResponse(string message) 
        {
            Message = message;
        }
    }
}
