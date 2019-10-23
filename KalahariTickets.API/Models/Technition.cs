using System.Collections.Generic;

namespace KalahariTickets.API.Models
{
    public class Technition
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MonthlySalary { get; set; }

        public int Age { get; set; }

         public ICollection<Tickets> Tickets { get; set; }

        //public byte[] PasswordHash {get;set;}

        //public byte[] PasswordSalt { get; set; }

    }
}