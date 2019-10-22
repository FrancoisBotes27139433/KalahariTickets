using System.Collections.Generic;
using System.Threading.Tasks;
using KalahariTickets.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

           /*.Include(t => t.Tickets)*/

           return client;

           // var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

           //return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = await _context.Clients.Include(t => t.Tickets).ToListAsync();

            /*.Include(t => t.Tickets)*/

            return clients;

           // var clients = await _context.Clients.ToListAsync();

           // return clients;
        }

        public async Task<Technition> GetTechnition(int id)
        {
           var technition = await _context.Technitions.Include(t => t.Tickets).FirstOrDefaultAsync(c => c.Id == id);

           /*.Include(t => t.Tickets)*/

           return technition;
        }

        public async Task<IEnumerable<Technition>> GetTechnitions()
        {
            var technitions = await _context.Technitions.Include(t => t.Tickets).ToListAsync();

            /*.Include(t => t.Tickets)*/

            return technitions;
        }

        public async  Task<Tickets> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            return ticket;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}