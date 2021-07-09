using System.Collections.Generic;

namespace FlightPlanner.Core.Dto
{
    public class PageResult
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<FlightDto> Items { get; set; }

        public PageResult()
        {
            Page = 0;
            TotalItems = 0;
            Items = new List<FlightDto>();
        }
    }
}