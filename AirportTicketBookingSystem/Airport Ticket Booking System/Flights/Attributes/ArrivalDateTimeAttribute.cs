namespace Airport_Ticket_Booking_System.Flights.Attributes
{
    public class ArrivalDateTimeAttribute : DepartureDateTimeAttribute
    {
        public ArrivalDateTimeAttribute(string property, string type, string constraint)
            : base(property, type, constraint) { }
        public bool IsValid(DateTime? d, DateTime? a) => a > d;
    }
}

