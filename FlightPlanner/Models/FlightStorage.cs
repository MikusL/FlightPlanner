using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightPlanner.Models
{
    public static class FlightStorage
    {
        public static IList<Flight> FlightList = new List<Flight>();
        private static readonly object _padlock = new object();
        private static int _id;

        public static Flight AddFlight(Flight flight)
        {
            foreach (var existingFlight in FlightList)
            {
                if (Checks.FlightEquals(existingFlight,flight))
                {
                    return flight;
                }
            }

            flight.Id = ++_id;
            FlightList.Add(flight);
            return flight;
        }

        public static Flight FindFlight(int id)
        {
            lock (_padlock)
            {
                return FlightList.FirstOrDefault(x => x.Id == id); 
            }
        }

        public static PageResult FindFlightsByRequest(SearchFlightsRequest request)
        {
            var result = new PageResult();

            foreach (var flight in FlightList)
            {
                if (Checks.FlightRequestCheck(request,flight))
                {
                    result.Items.Add(flight);
                    result.TotalItems++;
                }
            }

            return result;
        }
    }
}