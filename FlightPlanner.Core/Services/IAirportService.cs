using FlightPlanner.Core.Models;
using System.Collections.Generic;

namespace FlightPlanner.Core.Services
{
    public interface IAirportService : IEntityService<Flight>
    {
        void AddAirport(Airport airport);

        List<Airport> FindAirportByPhrase(string phrase);
    }
}
