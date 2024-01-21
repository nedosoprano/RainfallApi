using Microsoft.Extensions.DependencyInjection;

namespace Rainfall.Application.Extensions
{
    /// <summary>
    /// Extensions for including the HttpClient in applications using the Commands.Client NuGet package.
    /// </summary>
    public static class HttpClientBuilderExtensions
    {
        /// <summary>
        /// The UK Department for Environment Food & Rural Affairs base address.
        /// </summary>
        private const string GovEnvironmentBaseAddress = "https://environment.data.gov.uk";

        /// <summary>
        /// Adds the <see cref="IGovRainfallReadingsClient"/> to the provided <paramref name="services"/> <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to use.</param>
        public static IHttpClientBuilder AddCommandsClient(this IServiceCollection services)
        {
            return services
                .AddHttpClient<IGovRainfallReadingsClient, GovRainfallReadingsClient>()
                .ConfigureHttpClient((provider, client) =>
                {
                    client.BaseAddress = new Uri(GovEnvironmentBaseAddress);
                });
        }
    }
}
