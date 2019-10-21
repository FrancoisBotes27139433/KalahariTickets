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

         public virtual Client Client {get;set;}

         public virtual int ClientId { get; set; }

        public virtual Technition Technition {get;set;}
        public virtual int TechnitionId { get; set; }


         


    }
}