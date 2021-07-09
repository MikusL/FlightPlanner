using FlightPlanner.Core.Models;
using FlightPlanner.Data;
using System.Linq;

namespace FlightPlanner.Services.Validators
{
    public static class FlightAlreadyExistsValidator
    {
        public static bool Validate(Flight flight, IFlightPlannerDbContext context)
        {
            var flightList = context.Flights.ToList();

            return flightList.Any(f => FlightEquals(f, flight));
        }

        private static bool FlightEquals(Flight first, Flight second)
        {
            return AirportEquals(first.To, second.To) &&
                   AirportEquals(first.From, second.From) &&
                   StringClean(first.Carrier) == StringClean(second.Carrier) &&
                   StringClean(first.ArrivalTime) == StringClean(second.ArrivalTime) &&
                   StringClean(first.DepartureTime) == StringClean(second.DepartureTime);
        }

        private static bool AirportEquals(Airport first, Airport second)
        {
            return StringClean(first.AirportName) == StringClean(second.AirportName);
        }

        private static string StringClean(string result)
        {
            return result.Trim().ToLower();
        }
    }
}