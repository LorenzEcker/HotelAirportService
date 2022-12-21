namespace HotelAirportService.Domain.Base
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public bool Deleted { get; set; }
    }
}
