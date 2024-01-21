using Microsoft.Extensions.DependencyInjection;

namespace Rainfall.Application.Extensions
{
    /// <summary>
    /// Extensions for including the Application project dependency mappings in applications.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Application project dependency mappings to the provided <paramref name="services"/> <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to use.</param>
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRainfallReadingService, RainfallReadingService>();
            services.AddGovRainfallReadingsClient();

            return services;
        }
    }
}
