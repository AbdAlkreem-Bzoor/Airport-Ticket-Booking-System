using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Ticket_Booking_System.Flights.Attributes;

namespace Airport_Ticket_Booking_System.Flights
{
    public class Flight
    {
        [Countries("Departure Country", "Text", "Required")]
        public string? DepartureCountry { get; set; }

        [Countries("Destination Country", "Text", "Required")]
        public string? DestinationCountry { get; set; }

        [DepartureDateTime("Departure Date", "Date Time", "Required, Allowed Range (today → future)")]
        public DateTime? DepartureDate { get; set; }

        [ArrivalDateTime("Arrival Date", "Date Time", "Required, Allowed Range (today → future and after Departure Date)")]
        public DateTime? ArrivalDate { get; set; }

        [Airports("Departure Airport", "Text", "Required")]
        public string? DepartureAirport { get; set; }

        [Airports("Arrival Airport", "Text", "Required")]
        public string? ArrivalAirport { get; set; }

        public Flight(string? departureCountry, string? destinationCountry,
            DateTime? departureDate, DateTime? arrivalDate, string? departureAirport,
            string? arrivalAirport)
        {
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
        }

        public override string ToString()
        {
            return
                "Flight Information\n" +
                "----------------------------------------------\n" +
                $"From: {DepartureCountry} ({DepartureAirport})\n" +
                $"To: {DestinationCountry} ({ArrivalAirport})\n" +
                $"Departure: {DepartureDate?.ToString("yyyy-MM-dd HH:mm")}\n" +
                $"Arrival: {ArrivalDate?.ToString("yyyy-MM-dd HH:mm")}\n";

            // →
        }

    }
}


