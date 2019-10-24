using System;

namespace KalahariTickets.API.Dtos
{
    public class TicketForCreationDto
    {
       

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsUrgent { get; set; }

        public string Notes { get; set; }

        public DateTime DateIssued { get; set; }

         public DateTime DateClossed { get; set; }

         public bool Open { get; set; }
        public TicketForCreationDto()
        {
            //DateIssued = DateTime.Now;
            //DateClossed = 
            IsUrgent = false;
            Open = true;
           // Notes = "";
            //TechnitionId = null;
        }

    }
}