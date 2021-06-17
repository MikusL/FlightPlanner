using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FlightPlanner.DBContext;

namespace FlightPlanner.Models
{
    public static class FlightStorage
    {
        private static readonly object _padlock = new object();
        public static int Id;

        public static Flight AddFlight(Flight flight, FlightPlannerDbContext ctx)
        {
            flight.Id = ++Id;
            ctx.Flights.Add(flight);
            ctx.SaveChanges();
            return flight;
        }

        public static Flight FindFlight(int id, FlightPlannerDbContext ctx)
        {
            lock (_padlock)
            {
                return ctx.Flights.Include(f=>f.To).Include(f=>f.From).FirstOrDefault(x => x.Id == id); 
            }
        }

        public static PageResult FindFlightsByRequest(SearchFlightsRequest request, FlightPlannerDbContext ctx)
        {
            var result = new PageResult();

            var flightList = ctx.Flights.Include(f => f.From).Include(f => f.To).ToList();

            foreach (var flight in flightList)
            {
                if (!Checks.FlightRequestCheck(request, flight)) continue;

                result.Items.Add(flight);
                result.TotalItems++;
            }

            return result;
        }

        public static Flight TransformAddFlightRequestToFlight(AddFlightRequest request)
        {
            Flight result = new Flight
            (
                request.From,
                request.To,
                request.Carrier,
                request.DepartureTime,
                request.ArrivalTime
            );

            return result;
        }

        public static bool ChecksIfFlightAlreadyExist(Flight flight, FlightPlannerDbContext ctx)
        {
            var flightList = ctx.Flights.Include(f => f.From).Include(f => f.To).ToList();

            return flightList.Any(f => Checks.FlightEquals(f, flight));
        }
    }
}