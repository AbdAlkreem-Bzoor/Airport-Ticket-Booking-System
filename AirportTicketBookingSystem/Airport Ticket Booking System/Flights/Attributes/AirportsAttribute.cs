using Airport_Ticket_Booking_System.Repositry;

namespace Airport_Ticket_Booking_System.Flights.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AirportsAttribute : CountriesAttribute
    {
        public static readonly List<(string? country, List<(string? ariport, string? airportFullName)> airports)>
           countriesAirports = Repository.LoadCountriesAirports().ToList();
        public AirportsAttribute(string property, string type, string constraint)
           : base(property, type, constraint) { }
        public bool IsValid(string? airport, string? country) => IsValid(country) && countriesAirports
                                      .Any(x =>
                                      string.Equals(x.country, country) && x.airports
                                      .Any(y => string.Equals(y.ariport, airport) ||
                                      string.Equals(y.airportFullName, airport)));
    }
}

