using System.Collections.Generic;

namespace KalahariTickets.API.Models
{
    public class Technition
    {
        public int Id { get; set; }

        public string Name { get; set; }

         public ICollection<Tickets> Tickets { get; set; }
    }
}