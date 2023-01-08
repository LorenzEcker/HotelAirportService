using HotelAirportService.DataAccess.repository;
using HotelAirportService.Domain;
using HotelAirportService.Dto;

namespace HotelAirportService.BusinessLogic
{
    public class BookingService : IBookingService
    {
        private readonly IRideRepository rideRepository;
        private readonly IBookingRepository bookingRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IAirportRepository airportRepository;
        private readonly IDriverRepository driverRepository;

        public BookingService(IRideRepository rideRepository, IBookingRepository bookingRepository, ICustomerRepository customerRepository, IAirportRepository airportRepository, IDriverRepository driverRepository)
        {
            this.rideRepository = rideRepository;
            this.bookingRepository = bookingRepository;
            this.customerRepository = customerRepository;
            this.airportRepository = airportRepository;
            this.driverRepository = driverRepository;
        }

        public async Task<Ride?> TryBookRide(RideBookingDto rideBooking)
        {
            Booking booking = await GetBooking(rideBooking.BookingId);
            Customer customer = await GetCustomerForBooking(booking.CustomerId);
            Airport airport = await GetAirportForBooking(rideBooking.AirportId);

            List<Driver> allDrivers = (await driverRepository.GetAllAsync()).ToList();

            TimeOnly airportTime = TimeOnly.FromDateTime(rideBooking.TimeAtAirport);
            DateOnly airportDate = DateOnly.FromDateTime(rideBooking.TimeAtAirport);

            List<Ride> ridesForDay = await rideRepository.GetRidesForDay(airportDate);

            Dictionary<Guid, List<(TimeOnly, TimeOnly)>> driverOccupancy =
                new Dictionary<Guid, List<(TimeOnly, TimeOnly)>>();

            //create a map that shows every driver for the current day
            //and the start and end times of their rides already assigned to them.
            ridesForDay.ForEach(r =>
            {
                if (!driverOccupancy.ContainsKey(r.DriverId))
                {
                    driverOccupancy.Add(r.DriverId, new List<(TimeOnly, TimeOnly)>()
                    {
                        new(airportTime.AddMinutes(-airport.TypicalDriveTime),
                            airportTime.AddMinutes(airport.TypicalDriveTime))
                    });
                }
                else
                {
                    driverOccupancy.GetValueOrDefault(r.DriverId)?.Add(
                        new(
                            airportTime.AddMinutes(-airport.TypicalDriveTime),
                            airportTime.AddMinutes(airport.TypicalDriveTime))
                        );
                }
            });

            //check for driver with no occupation for the day
            //if it there is one assign ride to him
            foreach (var d in allDrivers)
            {
                if (!driverOccupancy.ContainsKey(d.Id))
                {
                    return await CreateRide(airport.Id, d.Id, customer.Id, airportDate);
                }
            }

            //check for drivers with time for current ride
            TimeOnly startTime = airportTime.AddMinutes(-airport.TypicalDriveTime);
            TimeOnly endTime = airportTime.AddMinutes(airport.TypicalDriveTime);

            ; foreach (var d in driverOccupancy)
            {
                foreach (var t in d.Value)
                {
                    if (!(startTime >= t.Item1 && startTime <= t.Item2))
                    {
                        return await CreateRide(airport.Id, d.Key, customer.Id, airportDate);
                    }
                }
            }
            return null;
        }

        private async Task<Ride?> CreateRide(Guid airportId, Guid driverId, Guid customerId, DateOnly airportDate)
        {
            Ride result = new Ride
            {
                AirportId = airportId,
                DriverId = driverId,
                CustomerId = customerId,
                Date = airportDate.ToDateTime(TimeOnly.MinValue),
                Notes = "Ride Notes"
            };
            await rideRepository.InsertAsync(result);
            return result;
        }

        private async Task<Booking> GetBooking(Guid bId)
        {
            return await bookingRepository.GetByIdAsync(bId);
        }

        private async Task<Customer> GetCustomerForBooking(Guid cId)
        {
            return await customerRepository.GetByIdAsync(cId);
        }

        private async Task<Airport> GetAirportForBooking(Guid aId)
        {
            return await airportRepository.GetByIdAsync(aId);
        }
    }
}