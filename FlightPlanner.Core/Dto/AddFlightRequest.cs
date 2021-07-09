﻿using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Dto
{
    public class AddFlightRequest : Entity
    {
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public AddFlightRequest(Airport from, Airport to, string carrier, string departureTime, string arrivalTime)
        {
            From = from;
            To = to;
            Carrier = carrier;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public AddFlightRequest()
        {

        }
    }
}