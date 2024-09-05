namespace Airport_Ticket_Booking_System.Flights.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DepartureDateTimeAttribute : ValidationAttribute
    {
        public DepartureDateTimeAttribute(string property, string type, string constraint)
            : base(property, type, constraint) { }
        public static bool IsValid(DateTime dt) => dt >= DateTime.Today;
    }
}

