using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Repositry;
using Airport_Ticket_Booking_System.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Users
{
    public class Manager : Person
    {
        public List<Ticket> _ticketList = Repository.LoadTickets();
        public List<Passenger> _passengerList = Repository.LoadPassengers();

        public Manager(string? id, string? name,
            DateTime? dateOfBirth, string? phoneNumber) : base(id, name, dateOfBirth, phoneNumber)
        {
            _ticketList = Repository.LoadTickets().ToList();
        }
        public void SearchParameters(string? departureCountry = null, string? destinationCountry = null,
            DateTime? departureDate = null, DateTime? arrivalDate = null, string? departureAirport = null,
            string? arrivalAirport = null, FlightClass? flightClass = null, double? price = null,
            string? id = null, string? name = null, DateTime? dateOfBirth = null, string? phoneNumber = null)
        {
            var search = new Ticket(new Flight(departureCountry, destinationCountry,
                departureDate, arrivalDate, departureAirport, arrivalAirport),
                flightClass, price);
            var passenger = new Passenger(id, name, dateOfBirth, phoneNumber);
            var tickets = _ticketList.Where(t => t.Equals(search)).ToList();
            var passengers = _passengerList.Where(p => p.Equals(passenger)).ToList();
            HashSet<Ticket> set = new HashSet<Ticket>();
            if (tickets is not null)
            {
                foreach (var ticket in tickets)
                {
                    set.Add(ticket);
                }
            }
            foreach (var p in passengers)
            {
                foreach (var ticket in p._myTicketList)
                {
                    set.Add(ticket);
                }
            }
            foreach (var ticket in set)
            {
                Console.WriteLine(ticket);
            }
        }
        public void WritePassengersDataOnFile()
        {
            Repository.WritePassengersData(_passengerList);
        }
    }
}

