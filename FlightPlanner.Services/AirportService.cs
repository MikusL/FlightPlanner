using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using FlightPlanner.Services.Validators;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        private readonly FlightPlannerDbContext _context;

        public AirportService(FlightPlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddAirport(Airport airport)
        {
            if (AirportAlreadyExistValidator.Validate(airport, _context)) return;

            _context.Airports.Add(airport);
            _context.SaveChanges();
        }

        public List<Airport> FindAirportByPhrase(string phrase)
        {
            phrase = Helper.CleanString(phrase);

            return _context.Airports.Where(airport => airport.AirportName.ToLower().Contains(phrase) ||
                                                      airport.City.ToLower().Contains(phrase) ||
                                                      airport.Country.ToLower().Contains(phrase)).ToList();
        }

        public static Airport FindAirportByName(Airport airport, IFlightPlannerDbContext context)
        {
            var result = context.Airports.FirstOrDefault(f => airport.AirportName == f.AirportName);

            return result ?? airport;
        }
    }
}
