using System.Data.Entity;
using FlightPlanner.Models;

namespace FlightPlanner.DBContext
{
    public class FlightPlannerDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        public FlightPlannerDbContext() : base("flight-planner")
        { 

        }
    }
}