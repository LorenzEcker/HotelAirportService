using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAirportService.Options
{
    public class AviationStackOptions
    {
        public static string POSITION = "AviationStack";

        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public string ApiVersion { get; set; }
        public string AirportController { get; set; }
    }
}
