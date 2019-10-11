using KalahariTickets.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KalahariTickets.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Value> Values { get; set; }
    }
}