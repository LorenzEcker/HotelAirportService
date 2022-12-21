using Microsoft.Extensions.Configuration;

namespace HotelAirportService.Extensions.ConfigurationBuilder
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddConfigurationFiles(this IConfigurationBuilder config)
        {
            config.AddJsonFile("appsettings.json");
            config.AddJsonFile("appsettings.cors.json");
            return config;
        }
    }
}
