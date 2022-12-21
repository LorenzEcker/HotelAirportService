using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAirportService.Extensions.WebApplication
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerToolSuite(this IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1.0/swagger.json", "Hotel Airport Api Service");

                //Do not show the whole model (for performance)
                options.DefaultModelExpandDepth(1);
                options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);

                options.DisplayRequestDuration();
            });
            return application;
        }
    }
}
