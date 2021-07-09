﻿using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services.Validators
{
    public class DepartureTimeValidator : IValidator
    {
        public bool Validate(AddFlightRequest flightRequest)
        {
            return !string.IsNullOrEmpty(flightRequest.DepartureTime);
        }
    }
}
