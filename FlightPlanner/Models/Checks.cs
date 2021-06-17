﻿using Microsoft.Ajax.Utilities;
using System;

namespace FlightPlanner.Models
{
    public class Checks
    {
        private static readonly object _padlock = new object();
        public static bool FlightEquals(Flight first, Flight second)
        {
            return AirportEquals(first.To, second.To) &&
                   AirportEquals(first.From, second.From) &&
                   StringClean(first.Carrier) == StringClean(second.Carrier) &&
                   StringClean(first.ArrivalTime) == StringClean(second.ArrivalTime) &&
                   StringClean(first.DepartureTime) == StringClean(second.DepartureTime);
        }

        public static bool AirportEquals(Airport first, Airport second)
        {
            lock (_padlock)
            {
                return StringClean(first.AirportName) == StringClean(second.AirportName);
            }
        }

        public static bool FlightNullCheck(Flight flight)
        {
            if (flight.From == null ||
                flight.To == null)
            {
                return true;
            }

            if (flight.ArrivalTime.IsNullOrWhiteSpace() ||
                flight.DepartureTime.IsNullOrWhiteSpace() ||
                flight.Carrier.IsNullOrWhiteSpace() ||
                AirportPropNullCheck(flight.From) ||
                AirportPropNullCheck(flight.To) ||
                StringClean(flight.To.AirportName) == StringClean(flight.From.AirportName))
            {
                return true;
            }

            var temp = DateTime.Parse(flight.DepartureTime);
            var temp2 = DateTime.Parse(flight.ArrivalTime);

            return temp2.Subtract(temp).TotalMinutes <= 0;
        }

        public static bool AirportPropNullCheck(Airport airport)
        {
            return airport.City.IsNullOrWhiteSpace() ||
                   airport.AirportName.IsNullOrWhiteSpace() ||
                   airport.Country.IsNullOrWhiteSpace();
        }

        public static bool FlightRequestCheck(SearchFlightsRequest request, Flight flight)
        {
            return StringClean(flight.To.AirportName) == StringClean(request.To) &&
                   StringClean(flight.From.AirportName) == StringClean(request.From) &&
                   DepartureTimeEquals(StringClean(request.DepartureTime),StringClean(flight.DepartureTime));
        }

        public static bool SearchFlightRequestNullCheck(SearchFlightsRequest request)
        {
            return request == null || request.From == null ||
                   request.To == null ||
                   StringClean(request.To) == StringClean(request.From) ||
                   request.DepartureTime == null;
        }

        public static bool DepartureTimeEquals(string requestDepartureTime, string flightDepartureTime)
        {
            requestDepartureTime = StringClean(requestDepartureTime);
            flightDepartureTime = StringClean(flightDepartureTime);

            if (requestDepartureTime.Length < flightDepartureTime.Length)
            {
                flightDepartureTime = flightDepartureTime.Substring(0, requestDepartureTime.Length);
            }

            return requestDepartureTime == flightDepartureTime;
        }

        public static string StringClean(string result)
        {
            return result.Trim().ToLower();
        }
    }
}