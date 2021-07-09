using FlightPlanner.Core.Models;
using System.Data.Entity;

namespace FlightPlanner.Data
{
    public class FlightPlannerDbContext : DbContext, IFlightPlannerDbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        public FlightPlannerDbContext() : base("flight-planner")
        {

        }
    }
}