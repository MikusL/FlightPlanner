using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightPlanner.Areas.HelpPage;

namespace FlightPlanner.Models
{
    public class AirportStorage
    {
        public static IList<Airport> AirportList = new List<Airport>();
        private static readonly object _padlock = new object();
        private static bool _contains;

        public static void AddAirport(Airport airport)
        {
            lock (_padlock)
            {
                _contains = false;

                foreach (var existingAirport in AirportList)
                {
                    if (Checks.AirportEquals(existingAirport, airport))
                    {
                        _contains = true;
                        break;
                    }
                }

                if (!_contains)
                {
                    AirportList.Add(airport);
                } 
            }
        }

        public static List<Airport> FindAirportByPhrase(string phrase)
        {
            phrase = Checks.StringClean(phrase);
            List<Airport> result = new List<Airport>();

            foreach (var airport in AirportList)
            {
                if (Checks.StringClean(airport.AirportName).Contains(phrase) ||
                    Checks.StringClean(airport.City).Contains(phrase) ||
                    Checks.StringClean(airport.Country).Contains(phrase))
                {
                    result.Add(airport);
                }
            }
            
            return result;
        }
    }
}