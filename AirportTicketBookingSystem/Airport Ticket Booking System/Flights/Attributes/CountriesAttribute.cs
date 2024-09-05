using Airport_Ticket_Booking_System.Repositry;

namespace Airport_Ticket_Booking_System.Flights.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CountriesAttribute : ValidationAttribute
    {
        public static readonly List<string?>
           countries = Repository.LoadCountriesAirports().Select(x => x.country).ToList();

        public CountriesAttribute(string property, string type, string constraint)
            : base(property, type, constraint) { }
        public static bool IsValid(string s) => countries
                                         .Any(x =>
                                         string.Equals(x, s, StringComparison.OrdinalIgnoreCase));
    }
}

