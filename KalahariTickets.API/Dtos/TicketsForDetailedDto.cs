using System;

namespace KalahariTickets.API.Dtos
{
    public class TicketsForDetailedDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsUrgent { get; set; }

        public string Notes { get; set; }

        public DateTime DateIssued { get; set; }

         public DateTime DateClossed { get; set; }

         public bool Open { get; set; }

    }
}