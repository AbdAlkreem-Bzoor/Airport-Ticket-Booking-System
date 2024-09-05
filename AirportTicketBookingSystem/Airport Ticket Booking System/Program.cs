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

            
            //var x = Repository.LoadCountriesAirports();
            //foreach (var i in x)
            //{
            //    Console.WriteLine($"{i.country}");
            //    foreach (var j in i.airports)
            //    {
            //        Console.WriteLine($"{j.airport} ({j.airportFullName})");
            //    }
            //}

            Console.ReadKey();
        }
    }
}
