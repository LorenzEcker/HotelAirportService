using HotelAirportService.DataAccess.context;
using HotelAirportService.DataAccess.seeding;
using HotelAirportService.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelAirportService.Extensions.WebApplication
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerToolSuite(this IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1.0/swagger.json", "Hotel Airport Api");

                //Do not show the whole model (for performance)
                options.DefaultModelExpandDepth(1);
                options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);

                options.DisplayRequestDuration();
            });
            return application;
        }

        public static IHost SeedDatabase(this IHost app)
        {
            SeedDataProvider seedDataProvider = new();

            SeedAirports();
            return app;

            void SeedAirports()
            {
                using (var scope = app.Services.CreateScope())
                {
                    IServiceProvider services = scope.ServiceProvider;

                    HotelAirportServiceContext context = services.GetRequiredService<HotelAirportServiceContext>();

                    List<Airport> airports = seedDataProvider.Airports;

                    airports.ForEach(a =>
                    {
                        if (!context.Airport.Any(p => p.AirportName == a.AirportName))
                        {
                            context.Airport.Add(a);
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
