using Newtonsoft.Json;

namespace FlightPlanner.Models
{
    public class Airport
    {
        [JsonIgnore]
        public int Id { get; set; }
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