using FlightPlanner.Core.Models;

namespace FlightPlanner.Services.Validators
{
    public class AirportValidator
    {
        public bool Validate(Airport airport)
        {
            return !string.IsNullOrWhiteSpace(airport?.City) &&
                   !string.IsNullOrWhiteSpace(airport.AirportName) &&
                   !string.IsNullOrWhiteSpace(airport.Country);
        }
    }
}
