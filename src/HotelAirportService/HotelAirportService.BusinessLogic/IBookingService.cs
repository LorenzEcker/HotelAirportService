using HotelAirportService.Domain;
using HotelAirportService.Dto;

namespace HotelAirportService.BusinessLogic;

public interface IBookingService
{
    Task<Ride?> TryBookRide(RideBookingDto rideBooking);
}