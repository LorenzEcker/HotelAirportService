using HotelAirportService.Extensions.ConfigurationBuilder;
using HotelAirportService.Extensions.DependencyInjection;
using HotelAirportService.Extensions.WebApplication;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfigurationFiles();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDatabases();
builder.Services.AddOptionServices();
builder.Services.AddSwagger();
builder.Services.AddCrossOriginRequests();
builder.Services.AddVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerToolSuite();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/v1.0/error");
    app.UseHsts();
}

app.MapControllers();

//using var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope();
//using var ctx = app.Services.GetService<HotelAirportServiceContext>();
//ctx.Database.Migrate();

app.Run();
