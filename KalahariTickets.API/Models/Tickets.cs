using System;

namespace KalahariTickets.API.Models
{
    public class Tickets
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsUrgent { get; set; }

        public string Notes { get; set; }

        public DateTime DateIssued { get; set; }

         public DateTime DateClossed { get; set; }

         public bool Open { get; set; }

         public  Client Client {get;set;}

         public  int ClientId { get; set; }

        // public int OpenTicketCount { get; set; }

       // public  Technition Technition {get;set;}
        //public int TechnitionId { get; set; }


         


    }
}