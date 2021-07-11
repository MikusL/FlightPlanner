namespace FlightPlanner.Services.Validators
{
    public static class Helper
    {
        public static string CleanString(string stringToClean)
        { 
            return stringToClean.Trim().ToLower();
        }
    }
}
