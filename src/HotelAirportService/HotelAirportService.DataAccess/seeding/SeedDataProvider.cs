using HotelAirportService.Domain;
using Newtonsoft.Json;

namespace HotelAirportService.DataAccess.seeding;

public class SeedDataProvider
{
    public List<Airport> Airports { get; private set; }

    public SeedDataProvider()
    {
        Airports = loadJsonFromFile<List<Airport>>("seeding/json/airports.json");
    }

    private TData loadJsonFromFile<TData>(string filePath)
    {
        using StreamReader r = new(filePath);
        string json = r.ReadToEnd();
        TData data = JsonConvert.DeserializeObject<TData>(json);
        return data;
    }
}