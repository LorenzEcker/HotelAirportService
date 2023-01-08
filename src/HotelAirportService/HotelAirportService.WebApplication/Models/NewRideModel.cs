using System.ComponentModel.DataAnnotations;
using HotelAirportService.Domain.Enum;

namespace HotelAirportService.WebApplication.Models;

public class NewRideModel
{
    [Required]
    [Range(1, 8)]
    public int Passengers { get; set; } = 1;
    [Required]
    public Guid AirportId { get; set; }
    [Required]
    public DateTime TimeAtAirport { get; set; }
    public Guid RideId { get; set; }
    public TravelType TravelType { get; set; }
}