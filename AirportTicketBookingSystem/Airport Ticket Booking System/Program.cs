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
            var p = new Passenger("202124", "Osama", DateTime.Now, "0593819201");

            p.SearchParameters("USA");
            p.SearchParameters(null, "USA"); // allow the user to search about the flight he want based on one parameter, two, thre and so on

            Manager m = new Manager("12234", "Ali", DateTime.Parse("1990-09-23"), "0483345987");
            m._passengerList.Add(p);
            m.WritePassengersDataOnFile();

            Console.ReadKey();
        }
    }
}
