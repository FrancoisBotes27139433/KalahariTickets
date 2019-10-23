using System;

namespace KalahariTickets.API.Dtos
{
    public class ClientForListDto
    {
        public int Id{ get; set; }
        public string Username { get; set; }
        public int PhoneNumber { get; set; }

        public string Email { get; set; } 

        public DateTime  DateAdded { get; set; }

        public string Address { get; set; }
    }
}