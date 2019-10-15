using System.Collections.Generic;
using System.Threading.Tasks;
using KalahariTickets.API.Models;
using Microsoft.EntityFrameworkCore;

namespace KalahariTickets.API.Data
{
    public class KalahariTicketsRepository : IKalahariTicketsInterface
    {
        private readonly DataContext _context;
        public KalahariTicketsRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public async Task<Client> GetClient(int id)
        {
           var client = await _context.Clients.Include(t => t.Tickets).FirstOrDefaultAsync(c => c.Id == id);

           return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = await _context.Clients.Include(t => t.Tickets).ToListAsync();

            return clients;
        }

        public async Task<Technition> GetTechnition(int id)
        {
           var technition = await _context.Technitions.Include(t => t.Tickets).FirstOrDefaultAsync(c => c.Id == id);

           return technition;
        }

        public async Task<IEnumerable<Technition>> GetTechnitions()
        {
            var technitions = await _context.Technitions.Include(t => t.Tickets).ToListAsync();

            return technitions;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}