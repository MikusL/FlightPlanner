using FlightPlanner.Data;
using System.Web.Http;

namespace FlightPlanner.Controllers
{
    public class TestingApiController : ApiController
    {
        private readonly IFlightPlannerDbContext _context;
        private static readonly object Padlock = new object();

        public TestingApiController(IFlightPlannerDbContext context)
        {
            _context = context;
        }

        [Route("testing-api/clear"), HttpPost]
        public IHttpActionResult Clear()
        {
            lock (Padlock)
            {
                _context.Flights.RemoveRange(_context.Flights);
                _context.Airports.RemoveRange(_context.Airports);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
