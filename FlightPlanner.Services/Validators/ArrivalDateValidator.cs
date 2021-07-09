using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class ArrivalDateValidator : IValidator
    {
        public bool Validate(AddFlightRequest flightRequest)
        {
            return !string.IsNullOrEmpty(flightRequest.ArrivalTime);
        }
    }
}
