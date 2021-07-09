using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Services.Validators
{
    public static class FindFlightBySearchRequest
    {
        public static bool Find(SearchFlightsRequest request, Flight flight)
        {
            return StringClean(flight.To.AirportName) == StringClean(request.To) &&
                   StringClean(flight.From.AirportName) == StringClean(request.From) &&
                   DepartureTimeEquals(StringClean(request.DepartureTime), StringClean(flight.DepartureTime));
        }

        private static bool DepartureTimeEquals(string requestDepartureTime, string flightDepartureTime)
        {
            requestDepartureTime = StringClean(requestDepartureTime);
            flightDepartureTime = StringClean(flightDepartureTime);

            if (requestDepartureTime.Length < flightDepartureTime.Length)
            {
                flightDepartureTime = flightDepartureTime.Substring(0, requestDepartureTime.Length);
            }

            return requestDepartureTime == flightDepartureTime;
        }

        private static string StringClean(string result)
        {
            return result.Trim().ToLower();
        }
    }
}
