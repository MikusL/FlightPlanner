using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Dto
{
    public class FlightDto : Entity
    {
        public AirportDto From { get; set; }
        public AirportDto To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public FlightDto(AirportDto from, AirportDto to, string carrier, string departureTime, string arrivalTime)
        {
            From = from;
            To = to;
            Carrier = carrier;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public FlightDto()
        {

        }
    }
}
