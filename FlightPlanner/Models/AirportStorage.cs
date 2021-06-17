using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightPlanner.Areas.HelpPage;
using FlightPlanner.DBContext;

namespace FlightPlanner.Models
{
    public class AirportStorage
    {
        private static readonly object _padlock = new object();
        private static bool _contains;

        public static void AddAirport(Airport airport, FlightPlannerDbContext ctx)
        {
            lock (_padlock)
            {
                _contains = false;

                if (ChecksIfAirportAlreadyExists(airport, ctx)) _contains = true;

                if (!_contains) ctx.Airports.Add(airport);
            }
        }

        public static List<Airport> FindAirportByPhrase(string phrase, FlightPlannerDbContext ctx)
        {
            phrase = Checks.StringClean(phrase);

            return ctx.Airports.Where(airport => airport.AirportName.ToLower().Contains(phrase) || airport.City.ToLower().Contains(phrase) || airport.Country.ToLower().Contains(phrase)).ToList();
        }

        public static bool ChecksIfAirportAlreadyExists(Airport airport, FlightPlannerDbContext ctx)
        {
            var airportList = ctx.Airports.ToList();

            return airportList.Any(a => Checks.AirportEquals(a,airport));
        }
    }
}