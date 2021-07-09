using AutoMapper;
using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using FlightPlanner.Services.Validators;
using System.Linq;

namespace FlightPlanner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        private readonly FlightPlannerDbContext _context;
        private int _id;
        public FlightService(FlightPlannerDbContext context) : base(context)
        {
            _context = context;
        }

        public Flight AddFlight(Flight flight)
        {
            flight.Id = ++_id;
            Create(flight);
            return flight;
        }

        public void DeleteFlight(Flight flight)
        {
            Delete(flight);
        }

        public Flight GetFullFlight(int id)
        {
            return Query().SingleOrDefault(f => f.Id == id);
        }

        public PageResult FindFlightsByRequest(SearchFlightsRequest request, IMapper mapper)
        {
            var result = new PageResult();

            var list = _context.Flights.ToList();

            var flightList = list.Where(f => FindFlightBySearchRequest.Find(request, f))
                                .Select(x => mapper.Map(x, new FlightDto()))
                                .ToList();

            result.TotalItems = flightList.Count;
            result.Items = flightList;

            return result;
        }

        public Flight TransformAddFlightRequestToFlight(AddFlightRequest request, IMapper mapper)
        {
            Flight result = new Flight();
            mapper.Map(request, result);
            return result;
        }
    }
}
