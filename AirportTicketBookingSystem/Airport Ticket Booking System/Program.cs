using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Repositry;
using Airport_Ticket_Booking_System.Tickets;
using Airport_Ticket_Booking_System.Users;

namespace Airport_Ticket_Booking_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Passenger("202", "Abdalkreem", DateTime.Now, "0594451851");
            for (int i = 0; i < p._ticketList.Count; i++)
            {
                p.AddTicket(p._ticketList[i].Id);
            }
            Console.WriteLine(p);
            Console.WriteLine("__________________________________________________________");
            var islam = new Passenger("203", "Islam", DateTime.Now, "0569788944");
            for (int i = 0; i < islam._ticketList.Count; i++)
            {
                islam.AddTicket(islam._ticketList[i].Id);
            }
            Console.WriteLine(islam);

            Console.ReadKey();
        }
    }
}
