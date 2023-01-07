using HotelAirportService.DataAccess.context;
using HotelAirportService.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using HotelAirportService.DataAccess.repository;

namespace HotelAirportService.Extensions.DependencyInjection
{
    public static class ServiceCollectionHelper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddScoped<HotelAirportServiceContext>();
            return services;
        }

        public static IServiceCollection AddDatabases(this IServiceCollection services)
        {
            DatabaseOptions databaseOptions = services.BuildServiceProvider().GetRequiredService<IOptions<DatabaseOptions>>().Value;

            services.AddDbContext<HotelAirportServiceContext>(options =>
            {
                options.UseSqlServer(databaseOptions.HotelAirportServiceDb);
            });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAirportRepository, AirportRepository>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.DocInclusionPredicate((version, apiDescription) =>
                {
                    apiDescription.TryGetMethodInfo(out MethodInfo methodinfo);

                    IEnumerable<ApiVersion> actionVersions = methodinfo
                        .GetCustomAttributes<MapToApiVersionAttribute>().SelectMany(attr => attr.Versions);

                    IEnumerable<ApiVersion> controllerVersions = methodinfo.DeclaringType
                        ?.GetCustomAttributes<ApiVersionAttribute>().SelectMany(attr => attr.Versions) ?? new List<ApiVersion>();

                    bool controllerAndActionsVersionOverlap = controllerVersions.Intersect(actionVersions).Any();

                    IEnumerable<ApiVersion> versions = controllerAndActionsVersionOverlap ? actionVersions : controllerVersions;

                    if (!versions.Any(v => $"v{v}" == version))
                    {
                        return false;
                    }

                    ApiParameterDescription? versionParameter = apiDescription.ParameterDescriptions.SingleOrDefault(desc => desc.Name == "version");

                    var className = methodinfo.DeclaringType?.Name;
                    var values = apiDescription.RelativePath?.Split('/').ToArray();

                    if (versionParameter != null)
                    {
                        if (values == null)
                            return false;
                        values[0] = version;
                        apiDescription.RelativePath = string.Join("/", values);
                    }

                    if (versionParameter != null)
                    {
                        apiDescription.ParameterDescriptions.Remove(versionParameter);
                    }

                    return true;
                });
                options.SwaggerDoc("v1.0", new OpenApiInfo { Title = "HotelAirportService Api", Version = "v1.0" });
            });
            return services;
        }

        public static IServiceCollection AddCrossOriginRequests(this IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            CorsOptions corsOptions = serviceProvider.GetRequiredService<IOptions<CorsOptions>>().Value;

            string policyName = corsOptions.PolicyName;

            services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                {
                    builder.WithHeaders(corsOptions.AllowedHeaders);
                    builder.WithOrigins(corsOptions.AllowedOrigins);
                    builder.WithMethods(corsOptions.AllowedMethods);
                });
            });
            return services;
        }

        public static IServiceCollection AddOptionServices(this IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

            services.Configure<CorsOptions>(configuration.GetSection(CorsOptions.POSITION));
            services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.POSITION));
            return services;
        }

        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            //add api versioning assume v1.0 as default if not specified
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            });

            //combine different ways of reading the API version (from a query string, request header, or media type)
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}