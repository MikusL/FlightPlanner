using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using FlightPlanner.Services.Validators;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner.Services
{
    public class AirportService : EntityService<Flight>, IAirportService
    {
        private readonly FlightPlannerDbContext _context;
        private bool _contains;

        public AirportService(FlightPlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddAirport(Airport airport)
        {
            _contains = false;

            if (AirportAlreadyExistValidator.Validate(airport, _context)) _contains = true;

            if (_contains) return;

            _context.Airports.Add(airport);
            _context.SaveChanges();
        }

        public List<Airport> FindAirportByPhrase(string phrase)
        {
            phrase = phrase.ToLower().Trim();

            return _context.Airports.Where(airport => airport.AirportName.ToLower().Contains(phrase) ||
                                                      airport.City.ToLower().Contains(phrase) ||
                                                      airport.Country.ToLower().Contains(phrase)).ToList();
        }
    }
}
