using FlightPlanner.Core.Dto;

namespace FlightPlanner.Services.Validators
{
    public static class SearchRequestValidator
    {
        public static bool Validate(SearchFlightsRequest request)
        {
            return request == null || request.From == null ||
                   request.To == null ||
                   Helper.CleanString(request.To) == Helper.CleanString(request.From) ||
                   request.DepartureTime == null;
        }
    }
}
