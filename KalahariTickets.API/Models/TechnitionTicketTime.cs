using System;

namespace KalahariTickets.API.Models
{
    public class TechnitionTicketTime
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Technition Technition {get;set;}

        public int TechnitionId {get;set;}

        public Tickets Tickets { get; set; }

        public int TicketId { get; set; }


    }
}