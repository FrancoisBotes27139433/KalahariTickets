using System;
using System.Collections.Generic;
using KalahariTickets.API.Models;

namespace KalahariTickets.API.Dtos
{
    public class ClientForDetailedDto
    {
         public int Id{ get; set; }
        public string Username { get; set; }
        public int PhoneNumber { get; set; }

        public string Email { get; set; } 

        public DateTime  DateAdded { get; set; }

        public string Address { get; set; }

        public ICollection<TicketsForDetailedDto> Tickets { get; set; }
    }
}