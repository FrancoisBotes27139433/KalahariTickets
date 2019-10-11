using System.Threading.Tasks;
using KalahariTickets.API.Data;
using KalahariTickets.API.Dtos;
using KalahariTickets.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace KalahariTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(ClientForRegisterDto clientForRegister)
        {
            // validate request
            
           clientForRegister.Username = clientForRegister.Username.ToLower();

            if(await _repo.UserExists(clientForRegister.Username))
                return BadRequest("Username already exists");
            
            var clientToCreate = new  Client
            {
                Username = clientForRegister.Username
            };

            var createdClient = await _repo.Register(clientToCreate, clientForRegister.Password);

            return StatusCode(201);

        }



    }
}