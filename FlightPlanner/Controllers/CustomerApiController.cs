using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightPlanner.Attributes;
using FlightPlanner.DBContext;
using FlightPlanner.Models;

namespace FlightPlanner.Controllers
{
    public class CustomerApiController : ApiController
    {
        [Route("api/airports")]
        public IHttpActionResult GetAirports(string search)
        {
            using (var ctx = new FlightPlannerDbContext())
            {
                var airport = AirportStorage.FindAirportByPhrase(search, ctx);

                return airport.Count == 0 ? (IHttpActionResult)NotFound() : Ok(airport); 
            }
        }

        [Route("api/flights/{id}")]
        public IHttpActionResult GetFlightById(int id)
        {
            using (var ctx = new FlightPlannerDbContext())
            {
                var flight = FlightStorage.FindFlight(id,ctx);

                return flight == null ? (IHttpActionResult)NotFound() : Ok(flight); 
            }
        }

        [Route("api/flights/search")]
        public IHttpActionResult PostFlights(SearchFlightsRequest req)
        {
            using (var ctx = new FlightPlannerDbContext())
            {
                if (Checks.SearchFlightRequestNullCheck(req)) return BadRequest();

                var result = FlightStorage.FindFlightsByRequest(req, ctx);

                return Ok(result); 
            }
        }
    }
}
