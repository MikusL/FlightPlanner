using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using FlightPlanner.Attributes;
using FlightPlanner.DBContext;
using FlightPlanner.Models;
using Microsoft.Ajax.Utilities;

namespace FlightPlanner.Controllers
{
    public class AdminApiController : ApiController
    {
        private static readonly object _padlock = new object();

        [Route("admin-api/flights/{id}")]
        [BasicAuthentication]
        public IHttpActionResult GetFlights(int id)
        {
            using (var ctx = new FlightPlannerDbContext())
            {
                var flight = FlightStorage.FindFlight(id,ctx);

                return flight == null ? (IHttpActionResult)NotFound() : Ok(flight); 
            }
        }

        [Route("admin-api/flights/{id}")]
        [BasicAuthentication]
        public IHttpActionResult DeleteFlight(int id)
        {
            lock (_padlock)
            {
                using (var ctx = new FlightPlannerDbContext())
                {
                    var flight = FlightStorage.FindFlight(id, ctx);

                    if (flight != null) ctx.Flights.Remove(flight);

                    ctx.SaveChanges();

                    return Ok();  
                }
            }
        }

        [Route("admin-api/flights")]
        [BasicAuthentication]
        public IHttpActionResult PutFlight(AddFlightRequest newFlight)
        {
            lock (_padlock)
            {
                using (var ctx = new FlightPlannerDbContext())
                {
                    Flight result = FlightStorage.TransformAddFlightRequestToFlight(newFlight);

                    if (Checks.FlightNullCheck(result)) return BadRequest();

                    if (FlightStorage.ChecksIfFlightAlreadyExist(result, ctx)) return Conflict();

                    AirportStorage.AddAirport(result.To, ctx);
                    AirportStorage.AddAirport(result.From, ctx);

                    ctx.SaveChanges();

                    return Created(string.Empty, FlightStorage.AddFlight(result,ctx));  
                }
            }
        }
    }
}
