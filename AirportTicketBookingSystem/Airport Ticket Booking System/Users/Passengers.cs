using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Tickets;
using Airport_Ticket_Booking_System.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Users
{
    public class Passenger : Person
    {
        internal List<Ticket> _ticketList = [];
        internal List<Ticket> _myTicketList = [];
        public Passenger(string? id, string? name,
            DateTime? dateOfBirth, string? phoneNumber) : base(id, name, dateOfBirth, phoneNumber)
        {
            _ticketList = Repository.LoadTickets().ToList();
        }

        public void SearchParameters(string? departureCountry = null, string? destinationCountry = null,
            DateTime? departureDate = null, DateTime? arrivalDate = null, string? departureAirport = null,
            string? arrivalAirport = null, FlightClass? flightClass = null, double? price = null)
        {
            var search = new Ticket(new Flight(departureCountry, destinationCountry,
                departureDate, arrivalDate, departureAirport, arrivalAirport),
                flightClass, price);

            var tickets = _ticketList.Where(t => t.Equals(search)).ToList();
            if (tickets is not null)
            {
                foreach (var ticket in tickets)
                {
                    Console.WriteLine(ticket);
                }
            }
        }
        public void AddTicket(int id)
        {
            _myTicketList.Add(_ticketList.Where(t => t.Id == id).First());
        }
        public void CancelTicket(int id)
        {
            _myTicketList.RemoveAll(t => t.Id == id);
        }
        public void ModifyTicket(int id)
        {
            int index = 0;
            foreach (var ticket in _myTicketList)
            {
                if (ticket.Id == id)
                {
                    Console.Write($"Enter the Ticket id that you want to replace with: ");
                    var x = Console.ReadLine() ?? "1";
                    _myTicketList[index] = _ticketList.Where(t => t.Id == int.Parse(x)).First();
                    break;
                }
                index++;
            }
        }
        public void Display()
        {
            foreach (var ticket in _myTicketList)
            {
                Console.WriteLine(ticket);
            }
        }
        public override string ToString()
        {
            if (_myTicketList.Count == 0)
                return $"Passenger {Name} has no tickets.";

            string toString = $"Passenger: {Name} (ID: {Id})\n" +
                              $"Date of Birth: {DateOfBirth?.ToString("yyyy-MM-dd")}\n" +
                              $"Phone Number: {PhoneNumber}\n" +
                              "|\n|\n|_______";

            foreach (var ticket in _myTicketList)
            {
                toString += $"\n|       |_ Ticket {ticket.Id}\n" +
                            $"|              | - Class: {ticket.FlightClass}\n" +
                            $"|              | - Price: {ticket.Price:C2}\n" +
                            $"|              |_______ Flight:\n" +
                            $"|                          |_ From: {ticket.Flight.DepartureCountry} ({ticket.Flight.DepartureAirport})\n" +
                            $"|                          |_ To: {ticket.Flight.DestinationCountry} ({ticket.Flight.ArrivalAirport})\n" +
                            $"|                          |_ Departure: {ticket.Flight.DepartureDate:yyyy-MM-dd HH:mm}\n" +
                            $"|                          |_ Arrival: {ticket.Flight.ArrivalDate:yyyy-MM-dd HH:mm}\n";
            }

            return toString;
        }


    }
}


