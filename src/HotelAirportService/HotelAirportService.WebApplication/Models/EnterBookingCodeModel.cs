using System.ComponentModel.DataAnnotations;

namespace HotelAirportService.WebApplication.Models;

public class EnterBookingCodeModel
{
    [Required]
    public string BookingCode { get; set; }
}