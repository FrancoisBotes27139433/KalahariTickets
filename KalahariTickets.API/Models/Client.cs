using System;
using System.Collections.Generic;

namespace KalahariTickets.API.Models
{
    public class Client
    {
        public int Id{ get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash {get;set;}

        public byte[] PasswordSalt { get; set; }
        
        public int PhoneNumber { get; set; }

        public string Email { get; set; } 

        public DateTime  DateAdded { get; set; }

        public string Address { get; set; }

        public IEnumerable<Tickets> Tickets { get; set; }

      //  public bool IsAdmin { get; set; }

      //public string Longitude { get; set; }
     // public string Latitude { get; set; }

      
    }
}