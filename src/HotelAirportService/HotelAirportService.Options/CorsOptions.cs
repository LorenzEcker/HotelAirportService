namespace HotelAirportService.Options
{
    public class CorsOptions
    {
        public const string POSITION = "Cors";

        public string PolicyName { get; set; } = default!;
        public string[] AllowedHeaders { get; set; } = default!;
        public string[] AllowedMethods { get; set; } = default!;
        public string[] AllowedOrigins { get; set; } = default!;
    }
}
