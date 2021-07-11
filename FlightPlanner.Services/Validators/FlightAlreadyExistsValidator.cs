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
                   Helper.CleanString(first.Carrier) == Helper.CleanString(second.Carrier) &&
                   Helper.CleanString(first.ArrivalTime) == Helper.CleanString(second.ArrivalTime) &&
                   Helper.CleanString(first.DepartureTime) == Helper.CleanString(second.DepartureTime);
        }

        private static bool AirportEquals(Airport first, Airport second)
        {
            return Helper.CleanString(first.AirportName) == Helper.CleanString(second.AirportName);
        }
    }
}