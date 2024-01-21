using RainfallApi.Models;

namespace RainfallApi.Exceptions
{
    public class InvalidRequestPropertyException : Exception
    {
        public ErrorDetail ErrorDetail { get; set; }
        public InvalidRequestPropertyException(string propertyName, string message) : base(message)
        {
            ErrorDetail = new ErrorDetail
            {
                PropertyName = propertyName,
                Message = message
            };
        }
    }
}
