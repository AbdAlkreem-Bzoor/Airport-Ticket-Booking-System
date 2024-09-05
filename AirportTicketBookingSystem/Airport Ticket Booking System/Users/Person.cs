using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Users
{
    public abstract class Person
    {

        protected Person(string? id, string? name, DateTime? dateOfBirth, string? phoneNumber)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }

        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} , Name: {Name} , Date of birth: {DateOfBirth} , Phone: {PhoneNumber}\n";
        }
    }
}

