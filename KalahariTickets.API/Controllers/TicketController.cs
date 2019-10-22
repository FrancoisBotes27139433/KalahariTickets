using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using KalahariTickets.API.Data;
using KalahariTickets.API.Dtos;
using KalahariTickets.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KalahariTickets.API.Controllers
{
    [Authorize]
    [Route("api/clients/{userId}/tickets")]
    [ApiController]

    public class TicketsController : ControllerBase
    {
        private readonly IKalahariTicketsInterface _repo;
        private readonly IMapper _mapper;
        public TicketsController(IKalahariTicketsInterface repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

      /*  [HttpGet("{id}", Name = "GetTicket")]
        
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticketFromRepo = _repo.GetTicket(id);

            var tickeToReturn = _mapper.Map<TicketForDetaildDto>(ticketFromRepo);
            
            return Ok(ticketFromRepo);
        }*/

        [HttpPost]
         public async Task<IActionResult> AddTicketForClient(int userId, string title, string description, TicketForCreationDto ticketForCreationDto)
         {
             if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var clientFromRepo = await _repo.GetClient(userId);

            ticketForCreationDto.Title = title;
            ticketForCreationDto.Description = description;

            var ticket = _mapper.Map<Tickets>(ticketForCreationDto);

            clientFromRepo.Tickets.Add(ticket);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not book ticket");


         }
        
    }
}