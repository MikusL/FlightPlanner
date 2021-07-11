using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Services.Validators
{
    public static class FindFlightBySearchRequest
    {
        public static bool Find(SearchFlightsRequest request, Flight flight)
        {
            return Helper.CleanString(flight.To.AirportName) == Helper.CleanString(request.To) &&
                   Helper.CleanString(flight.From.AirportName) == Helper.CleanString(request.From) &&
                   DepartureTimeEquals(Helper.CleanString(request.DepartureTime), Helper.CleanString(flight.DepartureTime));
        }

        private static bool DepartureTimeEquals(string requestDepartureTime, string flightDepartureTime)
        {
            requestDepartureTime = Helper.CleanString(requestDepartureTime);
            flightDepartureTime = Helper.CleanString(flightDepartureTime);

            if (requestDepartureTime.Length < flightDepartureTime.Length)
            {
                flightDepartureTime = flightDepartureTime.Substring(0, requestDepartureTime.Length);
            }

            return requestDepartureTime == flightDepartureTime;
        }
    }
}
