using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;
using System;

namespace FlightPlanner.Services.Validators
{
    public class DatesIntervalValidator : IValidator
    {
        public bool Validate(AddFlightRequest flightsRequest)
        {
            var arrivalDate = DateTime.Parse(flightsRequest.ArrivalTime);
            var departureDate = DateTime.Parse(flightsRequest.DepartureTime);
            return arrivalDate > departureDate;
        }
    }
}
