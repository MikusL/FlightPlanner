using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class AirportCodesValidator : IValidator
    {
        public bool Validate(AddFlightRequest flightsRequest)
        {
            return flightsRequest.To.AirportName.ToLower().Trim() != flightsRequest.From.AirportName.ToLower().Trim();
        }
    }
}
