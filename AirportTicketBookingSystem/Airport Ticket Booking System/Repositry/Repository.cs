using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Tickets;
using Airport_Ticket_Booking_System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Repositry
{
    public static class Repository
    {
        public static void WriteTicketsData(List<Ticket> tickets)
        {
            string path = @$"D:\OneDrive\Desktop\Airport Ticket Booking System\Output\TicketsOutputData.txt";
            using (var writer = new StreamWriter(path))
            {
                foreach (var ticket in tickets)
                {
                    writer.WriteLine(ticket);
                }
            }
        }
        public static List<Ticket> LoadTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Input\TicketsInputData.txt";
            using (var reader = new StreamReader(path))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) is not null)
                {
                    var str = line.Split(',');
                    var flight = new Flight(str[0], str[1], DateTime.Parse(str[2]),
                        DateTime.Parse(str[3]), str[4], str[5]);
                    var ticket = new Ticket(flight, (FlightClass)Enum.Parse(typeof(FlightClass), str[7]),
                                 double.Parse(str[8]));
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }

        public static void WritePassengersData(List<Passenger> passengers)
        {
            string path = @$"D:\OneDrive\Desktop\Airport Ticket Booking System\Output\PassengersOutputData.txt";
            using (var writer = new StreamWriter(path))
            {
                foreach (var passenger in passengers)
                {
                    writer.WriteLine(passenger.ToString());
                }
            }
        }
        public static List<Passenger> LoadPassengers()
        {
            List<Passenger> passengers = new List<Passenger>();
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Input\PassengersInputData.txt";
            using (var reader = new StreamReader(path))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) is not null)
                {
                    var str = line.Split(',');
                    var passenger = new Passenger(str[0].Trim(), str[1].Trim(),
                        DateTime.Parse(str[2].Trim()), str[3]);
                    passengers.Add(passenger);
                }
            }
            return passengers;
        }
        private static string ListToString(List<char> list)
        {
            var sb = new StringBuilder(list.Count);
            foreach (char c in list)
                sb.Append(c);
            return sb.ToString();
        }
        public static List<(string? country, List<(string? airport, string? airportFullName)> airports)> LoadCountriesAirports()
        {
            var countriesAirports =
                new List<(string? country, List<(string? airport, string? airportFullName)> airports)>();
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Input\Airports_Countries.txt";
            using (var reader = new StreamReader(path))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) is not null)
                {
                    var country = ListToString(line.TakeWhile(c => c != ':').ToList());
                    var str = ListToString(line.SkipWhile(c => c != ':').ToList()).Split(',');
                    var airports = new List<(string? airport, string? airportFullName)>();
                    foreach (var s in str)
                    {
                        var x = s.Trim().Split('(');
                        var airport = x[0];
                        var airportFullName = x[1].TrimEnd(')');
                        airports.Add((airport, airportFullName));
                    }
                    countriesAirports.Add((country, airports));
                }
            }
            return countriesAirports;
        }
    }
}
