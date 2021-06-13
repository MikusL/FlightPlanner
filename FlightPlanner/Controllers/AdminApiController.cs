using System;
using System.Linq;
using System.Web.Http;
using FlightPlanner.Attributes;
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
            var flight = FlightStorage.FindFlight(id);

            return flight == null ? (IHttpActionResult) NotFound() : Ok(flight);
        }

        [Route("admin-api/flights/{id}")]
        [BasicAuthentication]
        public IHttpActionResult DeleteFlight(int id)
        {
            lock (_padlock)
            {
                var flight = FlightStorage.FindFlight(id);

                if (flight != null)
                {
                    FlightStorage.FlightList.Remove(flight);
                }

                return Ok(); 
            }
        }

        [Route("admin-api/flights")]
        [BasicAuthentication]
        public IHttpActionResult PutFlight(AddFlightRequest newFlight)
        {
            lock (_padlock)
            {
                Flight result = new Flight
                        (
                        newFlight.From,
                        newFlight.To,
                        newFlight.Carrier,
                        newFlight.DepartureTime,
                        newFlight.ArrivalTime
                        );

                if (Checks.FlightNullCheck(result))
                {
                    return BadRequest();
                }

                if (FlightStorage.FlightList.Count != 0)
                {
                    foreach (var flight in FlightStorage.FlightList)
                    {
                        if (Checks.FlightEquals(flight, result))
                        {
                            return Conflict();
                        }
                    }
                }

                AirportStorage.AddAirport(result.To);
                AirportStorage.AddAirport(result.From);

                return Created(string.Empty, FlightStorage.AddFlight(result)); 
            }
        }
    }
}
