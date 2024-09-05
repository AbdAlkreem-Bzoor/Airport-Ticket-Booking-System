using Airport_Ticket_Booking_System.Errors;
using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Flights.Attributes;
using Airport_Ticket_Booking_System.Tickets;
using Airport_Ticket_Booking_System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
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
            var tickets = new List<Ticket>();
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Input\TicketsInputData.txt";
            using (var reader = new StreamReader(path))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) is not null)
                {
                    var str = line.Split(',');
                    for (int i = 0; i < str.Length; i++)
                        str[i] = str[i].Trim();
                    var flight = new Flight(str[0], str[1], DateTime.Parse(str[2]),
                        DateTime.Parse(str[3]), str[4], str[5]);
                    var ticket = new Ticket(flight, (FlightClass)Enum.Parse(typeof(FlightClass), str[7]),
                                 double.Parse(str[8]));
                    tickets.Add(ticket);
                }
            }
            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket);
            }
            var errors = new List<Error>();
            foreach (var ticket in tickets)
            {
                var flight = ticket.Flight;
                var properties = flight.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var value = property.GetValue(flight);
                    var attributes = property.GetCustomAttributes();
                    foreach (var attribute in attributes)
                    {
                        if (attribute is AirportsAttribute)
                        {
                            var attr = (AirportsAttribute)attribute;
                            if (attr.Property == "Departure Airport")
                            {
                                var otherProp = properties
                                    .FirstOrDefault(x => x.Name.EndsWith("DepartureCountry"));
                                if (otherProp is not null
                                    && attr.IsValid((string?)value, (string?)otherProp.GetValue(flight)))
                                {
                                    errors.Add(new Error(attr.Property + "\n",
                                    "\t" + attr.Type + "\n" +
                                    "\t" + attr.Constraint + "\n"));
                                }
                            }
                            else
                            {
                                var otherProp = properties
                                    .FirstOrDefault(x => x.Name.EndsWith("DestinationCountry"));
                                if (otherProp is not null
                                    && attr.IsValid((string?)value, (string?)otherProp.GetValue(flight)))
                                {
                                    errors.Add(new Error(attr.Property + "\n",
                                    "\t" + attr.Type + "\n" +
                                    "\t" + attr.Constraint + "\n"));
                                }
                            }
                        }
                        else if (attribute is CountriesAttribute)
                        {
                            var attr = (CountriesAttribute)attribute;
                            if (!attr.IsValid((string?)value))
                            {
                                errors.Add(new Error(attr.Property + "\n",
                                    "\t" + attr.Type + "\n" +
                                    "\t" + attr.Constraint + "\n"));
                            }
                        }
                        else if (attribute is ArrivalDateTimeAttribute)
                        {
                            var attr = (ArrivalDateTimeAttribute)attribute;
                            var otherProp = properties
                                    .FirstOrDefault(x => x.Name.EndsWith("DepartureDate"));
                            if (otherProp is not null
                                && attr.IsValid((DateTime?)value, (DateTime?)otherProp.GetValue(flight)))
                            {
                                errors.Add(new Error(attr.Property + "\n",
                                "\t" + attr.Type + "\n" +
                                "\t" + attr.Constraint + "\n"));
                            }

                        }
                        else if (attribute is DepartureDateTimeAttribute)
                        {
                            var attr = (DepartureDateTimeAttribute)attribute;
                            if (!attr.IsValid((DateTime?)value))
                            {
                                errors.Add(new Error(attr.Property + "\n",
                                    "\t" + attr.Type + "\n" +
                                    "\t" + attr.Constraint + "\n"));
                            }
                        }
                    }

                }
            }
            if (errors.Count > 0)
            {
                Console.WriteLine($"There is {errors.Count} errors in the input data, reinput them based on these conditions: ");
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                    Console.WriteLine();
                }
                return [];
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
                    var str = ListToString(line.SkipWhile(c => c != ':').Skip(1).ToList()).Split(',');
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
