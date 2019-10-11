using System;
namespace KalahariTickets.API.Models
{
    public class Client
    {
        public int ClientId{ get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash {get;set;}

        public byte[] PasswordSalt { get; set; }

      
    }
}