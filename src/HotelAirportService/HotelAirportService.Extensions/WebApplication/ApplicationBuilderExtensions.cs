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
            SeedDrivers();
            SeedCustomers();
            SeedBookings();
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

            void SeedDrivers()
            {
                using (var scope = app.Services.CreateScope())
                {
                    IServiceProvider services = scope.ServiceProvider;

                    HotelAirportServiceContext context = services.GetRequiredService<HotelAirportServiceContext>();

                    List<Driver> drivers = seedDataProvider.Drivers;

                    drivers.ForEach(driver =>
                    {
                        if (!context.Driver.Any(e => e.DriverName == driver.DriverName))
                        {
                            context.Driver.Add(driver);
                        }
                    });
                    context.SaveChanges();
                }
            }

            void SeedCustomers()
            {
                using (var scope = app.Services.CreateScope())
                {
                    IServiceProvider services = scope.ServiceProvider;

                    HotelAirportServiceContext context = services.GetRequiredService<HotelAirportServiceContext>();

                    List<Customer> customers = seedDataProvider.Customers;

                    customers.ForEach(customer =>
                    {
                        if (!context.Customer.Any(e => e.CustomerName == customer.CustomerName))
                        {
                            context.Customer.Add(customer);
                        }
                    });
                    context.SaveChanges();
                }
            }

            void SeedBookings()
            {
                using (var scope = app.Services.CreateScope())
                {
                    IServiceProvider services = scope.ServiceProvider;

                    HotelAirportServiceContext context = services.GetRequiredService<HotelAirportServiceContext>();

                    List<Booking> bookings = seedDataProvider.Bookings;

                    bookings.ForEach(booking =>
                    {
                        if (!context.Booking.Any(b => b.BookingCode == booking.BookingCode))
                        {
                            context.Booking.Add(booking);
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
