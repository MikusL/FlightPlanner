using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class CarrierValidator : IValidator
    {
        public bool Validate(AddFlightRequest flightsRequest)
        {
            return !string.IsNullOrEmpty(flightsRequest.Carrier);
        }
    }
}
