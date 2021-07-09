using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class AirportToValidator : AirportValidator, IValidator
    {
        public bool Validate(AddFlightRequest flightsRequest)
        {
            return Validate(flightsRequest.To);
        }
    }
}
