using HotelAirportService.Extensions.ConfigurationBuilder;
using HotelAirportService.Extensions.DependencyInjection;
using HotelAirportService.Extensions.WebApplication;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfigurationFiles();
builder.Services.AddOptionServices();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddDatabases();
builder.Services.AddLocalization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerToolSuite();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseCors();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRequestLocalization(options => options.AddSupportedCultures("en", "de-AT").AddSupportedUICultures("en", "de-AT").SetDefaultCulture("de-AT"));
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();