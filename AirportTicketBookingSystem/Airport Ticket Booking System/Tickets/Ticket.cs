﻿using Airport_Ticket_Booking_System.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Tickets
{
    public class Ticket
    {
        private static int sequence = 0;
        private int _id;

        public Ticket(Flight flight, FlightClass? flightClass, double? price)
        {
            Id = sequence++;
            Flight = flight;
            FlightClass = flightClass;
            Price = price;
        }
        public int Id { get; init; }
        public Flight Flight { get; init; }
        public FlightClass? FlightClass { get; init; }
        public double? Price { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Ticket)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var other = (Ticket)obj;
            bool result = true;
            if (other.Flight.DepartureCountry is not null)
            {
                result = result && Flight.DepartureCountry == other.Flight.DepartureCountry;
            }
            if (other.Flight.DestinationCountry is not null)
            {
                result = result && Flight.DestinationCountry == other.Flight.DestinationCountry;
            }
            if (other.Flight.DepartureDate is not null)
            {
                result = result && Flight.DepartureDate == other.Flight.DepartureDate;
            }
            if (other.Flight.ArrivalDate is not null)
            {
                result = result && Flight.ArrivalDate == other.Flight.ArrivalDate;
            }
            if (other.Flight.DepartureAirport is not null)
            {
                result = result && Flight.DepartureAirport == other.Flight.DepartureAirport;
            }
            if (other.Flight.ArrivalAirport is not null)
            {
                result = result && Flight.ArrivalAirport == other.Flight.ArrivalAirport;
            }
            if (other.FlightClass is not null)
            {
                result = result && FlightClass == other.FlightClass;
            }
            if (other.Price is not null)
            {
                result = result && Price == other.Price;
            }
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Flight.DepartureCountry, Flight.DestinationCountry,
                Flight.DepartureDate, Flight.ArrivalDate, Flight.DepartureAirport,
                Flight.ArrivalAirport, FlightClass, Price);
        }
        public override string ToString()
        {
            return
                "Ticket Information\n" +
                "----------------------------------------------\n" +
                $"Ticket Number: {Id}\n" +
                $"Class: {FlightClass}\n" +
                $"Price: {Price:C2}\n" +
                $"{Flight}\n"; // Flight information
        }

    }
}

