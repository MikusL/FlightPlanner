using AutoMapper;
using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight AddFlight(Flight flight);

        void DeleteFlight(Flight flight);

        Flight GetFullFlight(int id);

        PageResult FindFlightsByRequest(SearchFlightsRequest request, IMapper mapper);

        Flight TransformAddFlightRequestToFlight(AddFlightRequest request, IMapper mapper);
    }
}
