using FlightPlanner.Core.Models;
using System.Collections.Generic;
using AutoMapper;
using FlightPlanner.Core.Dto;

namespace FlightPlanner.Core.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        void AddAirport(Airport airport);

        List<Airport> FindAirportByPhrase(string phrase);
    }
}
