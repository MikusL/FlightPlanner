using FlightPlanner.Core.Dto;

namespace FlightPlanner.Services.Validators
{
    public static class SearchRequestValidator
    {
        public static bool Validate(SearchFlightsRequest request)
        {
            return request == null || request.From == null ||
                   request.To == null ||
                   StringClean(request.To) == StringClean(request.From) ||
                   request.DepartureTime == null;
        }

        private static string StringClean(string result)
        {
            return result.Trim().ToLower();
        }
    }
}
