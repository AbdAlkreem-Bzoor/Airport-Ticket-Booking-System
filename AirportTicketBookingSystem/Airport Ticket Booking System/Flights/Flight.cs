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
        public int Id { get; init; }
        [Countries("Departure Country", "Text", "Required")]
        public string? DepartureCountry { get; set; }

        [Countries("Destination Country", "Text", "Required")]
        public string? DestinationCountry { get; set; }

        [DepartureDateTime("Departure Date", "Date Time", "Required, Allowed Range (today → future)")]
        public DateTime? DepartureDate { get; set; }
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }
        private static int sequence = 0;
        public Flight(string? departureCountry, string? destinationCountry,
            DateTime? departureDate, string? departureAirport,
            string? arrivalAirport)
        {
            Id = sequence++;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureDate = departureDate;
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
                $"Departure: {DepartureDate?.ToString("yyyy-MM-dd HH:mm")}\n";
            // →
        }

    }
}


