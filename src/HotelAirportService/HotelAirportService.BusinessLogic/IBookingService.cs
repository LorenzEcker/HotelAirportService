using HotelAirportService.Domain;
using HotelAirportService.Dto;

namespace HotelAirportService.BusinessLogic;

public interface IBookingService
{
    Ride? TryBookRide(RideBookingDto rideBooking);
}