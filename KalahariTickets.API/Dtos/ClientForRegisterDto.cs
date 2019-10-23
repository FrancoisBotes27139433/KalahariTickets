using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KalahariTickets.API.Dtos
{
    public class ClientForRegisterDto
    {
        public int Id{ get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        
       // public string Username { get; set; }
        public int PhoneNumber { get; set; }

        public string Email { get; set; } 

        public DateTime  DateAdded { get; set; }

        public string Address { get; set; }

        public ICollection<TicketsForDetailedDto> Tickets { get; set; }
    }
}