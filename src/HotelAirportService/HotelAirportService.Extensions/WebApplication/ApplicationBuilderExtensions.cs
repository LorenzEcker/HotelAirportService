using Microsoft.AspNetCore.Builder;

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
    }
}
