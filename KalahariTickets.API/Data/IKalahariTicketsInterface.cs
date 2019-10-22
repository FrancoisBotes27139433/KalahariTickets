using System.Collections.Generic;
using System.Threading.Tasks;
using KalahariTickets.API.Models;

namespace KalahariTickets.API.Data
{
    public interface IKalahariTicketsInterface
    {
         void Add<T>(T entity) where T: class;

         void Delete<T>(T entity) where T: class;

         Task<bool> SaveAll();

         Task<IEnumerable<Client>> GetClients();

         Task<Client> GetClient(int id);

         Task<IEnumerable<Technition>> GetTechnitions();

         Task<Technition> GetTechnition(int id);

         Task<Tickets> GetTicket(int id);

         Task<IEnumerable<Tickets>> GetTickets();

        Task<List<Tickets>> GetOpenTicketsForClient(int id);



    }
}