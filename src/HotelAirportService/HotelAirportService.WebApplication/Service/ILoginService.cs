using HotelAirportService.Domain;

namespace HotelAirportService.WebApplication.Service;

public interface ILoginService
{
    Task<bool> LoginCustomerAsync(string bookingCode);
    void LogoutCustomer();
}