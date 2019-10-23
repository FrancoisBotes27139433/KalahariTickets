using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KalahariTickets.API.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Technition> AddTechnition(Technition technition)
        {

       

            await _context.Technitions.AddAsync(technition);
            await _context.SaveChangesAsync();

            return technition;
        }

        // public Task<Technition> AddTechnition(tech)
        // {
        //    
        //

        // await _context.Clients.AddAsync(client);
        //await _context.SaveChangesAsync();

        //return client;


        //}

        /// public Task<Technition> AddTechnition(Technition technition)
        // {
        ///technition.Age = 


        // await _context.Clients.AddAsync(client);
        //            await _context.SaveChangesAsync();

        //  return client;

        //public Task<Technition> AddTechnition(Technition technition)
        //{
        //     

        //client.PasswordHash = passwordHash;
        // client.PasswordSalt = passwordSalt;

        //await _context.Clients.AddAsync(client);
        //await _context.SaveChangesAsync();

        // return client;
        // }

        //}

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

        public async Task<List<Tickets>> GetOpenTicketsForClient(int userId)
        {
            return await _context.Tickets.Where(u => u.ClientId == userId).ToListAsync();
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

        public async Task<Tickets> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            return ticket;
        }

   

        public async Task<IEnumerable<Tickets>> GetTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();

            return tickets;
        }




        // public async Task<IEnumerable<Tickets>> GetTickets(int userId, int id)
        //{//            return await _context.Tickets.Where(u => u.ClientId == userId).FirstOrDefaultAsync(t => t.Id == id);

        //    
        //}

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> TechnitionExists(string firstName)
        {
           if(await _context.Technitions.AnyAsync(x => x.FirstName == firstName))
                return true;

            return false;
        }
    }
}