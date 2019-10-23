using KalahariTickets.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KalahariTickets.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Client> Clients { get; set; }

        public DbSet<Tickets> Tickets { get; set; }

        public DbSet<Technition> Technitions { get; set; }
        public DbSet<TechnitionTicketTime> TechnitionTicketTimes { get; set; }



        
    }
}