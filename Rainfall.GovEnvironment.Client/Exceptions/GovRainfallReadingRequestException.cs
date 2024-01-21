namespace Rainfall.GovEnvironment.Client.Exceptions
{
    public class GovRainfallReadingRequestException : Exception
    {
        public GovRainfallReadingRequestException(string message) 
            : base($"Error occured during receiving data from the UK Department for Environment Food & Rural Affairs API: {message}") { }
    }
}
