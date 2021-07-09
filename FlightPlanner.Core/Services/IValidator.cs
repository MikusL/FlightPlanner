﻿using FlightPlanner.Core.Dto;

namespace FlightPlanner.Core.Services
{
    public interface IValidator
    {
        bool Validate(AddFlightRequest flightsRequest);
    }
}
