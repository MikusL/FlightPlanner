using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightPlanner.Models
{
    public class SearchFlightsRequest
    {
        public string To { get; set; }
        public string From { get; set; }
        public string DepartureTime { get; set; }

        public SearchFlightsRequest(string to, string from, string departureDate)
        {
            To = to;
            From = from;
            DepartureTime = departureDate;
        }
    }
}