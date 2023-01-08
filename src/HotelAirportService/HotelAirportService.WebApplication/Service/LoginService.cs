using System.Net.Http.Json;
using HotelAirportService.Domain;

namespace HotelAirportService.WebApplication.Service;

public class LoginService : ILoginService
{
    private HttpClient httpClient;

    public Booking Booking { get; private set; } = new Booking();
    public bool IsLoggedIn { get; private set; } = false;

    public LoginService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<bool> LoginCustomerAsync(string bookingCode)
    {
        Booking booking = await httpClient
            .GetFromJsonAsync<Booking>($"http://localhost:5030/api/v1.0/Booking/{bookingCode}");
        if (booking == null)
        {
            return false;
        }
        else
        {
            this.Booking = booking;
            return true;
        }
    }

    public void LogoutCustomer()
    {
        this.Booking = new Booking();
        this.IsLoggedIn = false;
    }
}