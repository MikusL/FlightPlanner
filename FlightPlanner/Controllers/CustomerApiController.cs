using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightPlanner.Attributes;
using FlightPlanner.Models;

namespace FlightPlanner.Controllers
{
    public class CustomerApiController : ApiController
    {
        [Route("api/airports")]
        public IHttpActionResult GetAirports(string search)
        {
            var airport = AirportStorage.FindAirportByPhrase(search);

            return airport.Count == 0 ? (IHttpActionResult)NotFound() : Ok(airport);
        }

        [Route("api/flights/{id}")]
        public IHttpActionResult GetFlightById(int id)
        {
            var flight = FlightStorage.FindFlight(id);

            return flight == null ? (IHttpActionResult)NotFound() : Ok(flight);
        }

        [Route("api/flights/search")]
        public IHttpActionResult PostFlights(SearchFlightsRequest req)
        {
            if (req == null || Checks.SearchFlightRequestNullCheck(req))
            {
                return BadRequest();
            }

            var result = FlightStorage.FindFlightsByRequest(req);

            return Ok(result);
        }
    }
}
