using AutoMapper;
using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;
using FlightPlanner.Services.Validators;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlightPlanner.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CustomerApiController : ApiController
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;

        public CustomerApiController(IFlightService flightService, IAirportService airportService, IMapper mapper)
        {
            _flightService = flightService;
            _airportService = airportService;
            _mapper = mapper;
        }

        [Route("api/airports")]
        [HttpGet]
        public IHttpActionResult GetAirports(string search)
        {
            var airport = _airportService.FindAirportByPhrase(search);

            return airport.Count == 0 ? (IHttpActionResult)NotFound() : Ok(airport.Select(a => _mapper.Map<AirportDto>(a)).ToList());
        }

        [Route("api/flights/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightById(int id)
        {
            var flight = _flightService.GetFullFlight(id);

            return flight == null ? (IHttpActionResult)NotFound() : Ok(_mapper.Map(flight, new FlightDto()));
        }

        [Route("api/flights/search")]
        [HttpPost]
        public IHttpActionResult PostFlights(SearchFlightsRequest request)
        {
            if (SearchRequestValidator.Validate(request)) return BadRequest();

            var result = _flightService.FindFlightsByRequest(request, _mapper);

            return Ok(result);
        }
    }
}
