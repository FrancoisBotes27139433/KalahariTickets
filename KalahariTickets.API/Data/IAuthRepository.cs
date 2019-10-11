using System.Threading.Tasks;
using KalahariTickets.API.Models;

namespace KalahariTickets.API.Data
{
    public interface IAuthRepository
    {
         Task<Client> Register(Client client, string password);

         Task<Client> Login(string username, string password);

         Task<bool> UserExists(string username);

         Task<bool> Admin(string username);
    }
}