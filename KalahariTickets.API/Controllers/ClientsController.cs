using System.Threading.Tasks;
using KalahariTickets.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace KalahariTickets.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ClientsController : ControllerBase
    {
        private readonly KalahariTicketsRepository _repo;
        public ClientsController(KalahariTicketsRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _repo.GetClients();

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _repo.GetClient(id);

            return Ok(client);
        }
    }
}