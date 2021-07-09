using Newtonsoft.Json;

namespace FlightPlanner.Core.Models
{
    public class Airport : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty("airport")]
        public string AirportName { get; set; }

        public Airport(string country, string city, string airport)
        {
            Country = country;
            City = city;
            AirportName = airport;
        }

        public Airport()
        {

        }
    }
}