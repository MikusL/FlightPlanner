using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class AirportFromValidator : AirportValidator, IValidator
    {
        public bool Validate(AddFlightRequest flightRequest)
        {
            return Validate(flightRequest.From);
        }
    }
}
