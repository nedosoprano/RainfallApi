namespace Rainfall.Application.Exceptions
{
    public class RainfullReadingsEmptyException : Exception
    {
        public RainfullReadingsEmptyException() : base("No readings found for the specified stationId.") { }
    }
}
