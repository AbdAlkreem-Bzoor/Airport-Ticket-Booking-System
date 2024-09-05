using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Flights
{
    [Flags]
    public enum FlightClass
    {
        None = 0,
        Economy = 1,
        Business = 2,
        FirstClass = 4,
    }
}
