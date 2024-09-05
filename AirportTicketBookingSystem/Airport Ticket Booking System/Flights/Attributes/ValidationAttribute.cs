namespace Airport_Ticket_Booking_System.Flights.Attributes
{
    public class ValidationAttribute : Attribute
    {
        public ValidationAttribute(string property, string type, string constraint)
        {
            Property = property;
            Type = type;
            Constraint = constraint;
        }

        public string Property { get; init; }
        public string Type { get; init; }
        public string Constraint { get; init; }
    }
}

