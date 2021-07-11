using FlightPlanner.Core.Models;
using FlightPlanner.Data;
using System.Linq;

namespace FlightPlanner.Services.Validators
{
    public static class AirportAlreadyExistValidator
    {
        public static bool Validate(Airport airport, IFlightPlannerDbContext context)
        {
            var airportList = context.Airports.ToList();

            return airportList.Any(a => AirportEquals(a, airport));
        }
        private static bool AirportEquals(Airport first, Airport second)
        {
            return Helper.CleanString(first.AirportName) == Helper.CleanString(second.AirportName);
        }
    }
}
