using HotelAirportService.DataAccess.context;
using HotelAirportService.Extensions.ConfigurationBuilder;
using HotelAirportService.Extensions.DependencyInjection;
using HotelAirportService.Extensions.WebApplication;
using HotelAirportService.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfigurationFiles();

// Add services to the container.
builder.Services.AddOptionServices();
builder.Services.AddRepositories();
builder.Services.AddAppServices();
builder.Services.AddDatabases();
builder.Services.AddControllers();
builder.Services.AddCrossOriginRequests();
builder.Services.AddVersioning();
builder.Services.AddSwagger();

var app = builder.Build();

//Migrate Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<HotelAirportServiceContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerToolSuite();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    CorsOptions corsOptions = scope.ServiceProvider.GetRequiredService<IOptions<CorsOptions>>().Value;
    app.UseCors(corsOptions.PolicyName);
}


app.SeedDatabase();

app.MapControllers();

app.Run();
