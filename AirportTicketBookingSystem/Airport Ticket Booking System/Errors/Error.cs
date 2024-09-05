using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Errors
{
    public class Error
    {
        public string Property { get; init; }
        public string Message { get; init; }

        public Error(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public override string ToString()
        {
            return $"{Property}\n{Message}";
        }
    }
}
