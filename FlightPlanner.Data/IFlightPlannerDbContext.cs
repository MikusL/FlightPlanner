using FlightPlanner.Core.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FlightPlanner.Data
{
    public interface IFlightPlannerDbContext
    {
        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Flight> Flights { get; set; }
        DbSet<Airport> Airports { get; set; }

        int SaveChanges();
    }
}
