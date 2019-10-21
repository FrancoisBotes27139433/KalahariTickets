using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KalahariTickets.API.Data;
using KalahariTickets.API.Dtos;
using KalahariTickets.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KalahariTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(ClientForRegisterDto clientForRegisterDto)
        {
            // validate reguest 

            clientForRegisterDto.Username = clientForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(clientForRegisterDto.Username))
                return BadRequest("Username already exists");

            var clientToCreate = new Client
            {
                Username = clientForRegisterDto.Username
            };

            var createdClient = await _repo.Register(clientToCreate, clientForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(ClientForLoginDto clientForLoginDto)
        {
            var clientFromRepo = await _repo.Login(clientForLoginDto.Username, clientForLoginDto.Password);

            if (clientFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, clientFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, clientFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}