using AutoMapper;
using FlightPlanner.Attributes;
using FlightPlanner.Core.Dto;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using FlightPlanner.Services.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlightPlanner.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class AdminApiController : ApiController
    {
        private static readonly object Padlock = new object();
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidator> _validators;
        private readonly IFlightPlannerDbContext _context;

        public AdminApiController(IFlightService flightService, IAirportService airportService,
            IMapper mapper, IEnumerable<IValidator> validators, IFlightPlannerDbContext context)
        {
            _flightService = flightService;
            _airportService = airportService;
            _mapper = mapper;
            _validators = validators;
            _context = context;
        }

        [Route("admin-api/flights/{id}")]
        [BasicAuthentication]
        [HttpGet]
        public IHttpActionResult GetFlight(int id)
        {
            var flight = _flightService.GetFullFlight(id);

            if (flight != null) return Ok(flight);

            return NotFound();
        }

        [Route("admin-api/flights/{id}")]
        [BasicAuthentication]
        [HttpDelete]
        public IHttpActionResult DeleteFlight(int id)
        {
            lock (Padlock)
            {
                var flight = _flightService.GetFullFlight(id);

                if (flight == null) return NotFound();

                _flightService.DeleteFlight(flight);

                return Ok();
            }
        }

        [Route("admin-api/flights")]
        [BasicAuthentication]
        [HttpPut]
        public IHttpActionResult AddFlight(AddFlightRequest newFlight)
        {
            lock (Padlock)
            {
                if (!_validators.All(v => v.Validate(newFlight))) return BadRequest();

                var flight = _flightService.TransformAddFlightRequestToFlight(newFlight, _mapper);

                if (FlightAlreadyExistsValidator.Validate(flight, _context)) return Conflict();

                _airportService.AddAirport(flight.To);
                _airportService.AddAirport(flight.From);
                _flightService.AddFlight(flight);

                return Created(string.Empty, _mapper.Map(flight, new FlightDto()));
            }
        }
    }
}
