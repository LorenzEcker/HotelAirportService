using HotelAirportService.Domain;
using Newtonsoft.Json;

namespace HotelAirportService.DataAccess.seeding;

public class SeedDataProvider
{
    public List<Airport> Airports { get; private set; }
    public List<Customer> Customers { get; private set; }
    public List<Driver> Drivers { get; private set; }
    public List<Booking> Bookings { get; private set; }

    public SeedDataProvider()
    {
        Airports = loadJsonFromFile<List<Airport>>("seeding/json/airports.json");
        Drivers = loadJsonFromFile<List<Driver>>("seeding/json/drivers.json");
        Customers = loadJsonFromFile<List<Customer>>("seeding/json/customers.json");
        Bookings = loadJsonFromFile<List<Booking>>("seeding/json/bookings.json");
    }

    private TData loadJsonFromFile<TData>(string filePath)
    {
        using StreamReader r = new(filePath);
        string json = r.ReadToEnd();
        TData data = JsonConvert.DeserializeObject<TData>(json);
        return data;
    }
}