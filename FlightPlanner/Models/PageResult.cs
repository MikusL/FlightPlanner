using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightPlanner.Models
{
    public class PageResult
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Flight> Items { get; set; }

        public PageResult()
        {
            Page = 0;
            TotalItems = 0;
            Items = new List<Flight>();
        }
    }
}