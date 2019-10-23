using System.Linq;
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
        private readonly DataContext _context;
        public TicketsController(IKalahariTicketsInterface repo, IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet("{id}", Name = "GetTicket")]

        public async Task<IActionResult> GetTicket(int id)
        {
            var ticketFromRepo = await _repo.GetTicket(id);

            var tickeToReturn = _mapper.Map<TicketsForDetailedDto>(ticketFromRepo);

            return Ok(ticketFromRepo);
        }

        //[HttpGet]
        //public async Task<IActionResult> All(ClientForDetailedDto clientForDetailedDto)
        //{
            //var clients = await _context.Clients.GroupJoin(_context.Tickets.Where(ticket => ticket.Open), client => client.Id, ticket => ticket.ClientId, (client, tickets) => new ClientForDetailedDto{ client=} }).OrderByDescending(details => details.Tickets.Count()).ToListAsync();
            //return Ok(clients);
       // }

        //[HttpPost("GetOpenTickets")]

        [HttpGet]       
        public async Task<IActionResult> GetOpenTickets(int userId, int id, TicketsForDetailedDto ticketsForDetailedDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var clientFromRepo = await _repo.GetClient(userId);

            if(!clientFromRepo.Tickets.Any(t => t.Id == id ))
            return Unauthorized();

            var ticketFromRepo = await _repo.GetOpenTicketsForClient(userId);

            //var ticketToReturn = _mapper.Map<Tickets>(ticketFromRepo);

            return Ok(ticketFromRepo);
        }

        [HttpPost("GetAllTickets")]

        public async Task<IActionResult> GetAllTickets(int userId, TicketsForDetailedDto ticketsForDetailedDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var clientFromRepo = await _repo.GetClient(userId);

            //if(!clientFromRepo.Tickets.Any(t => t.Id == id ))
            // return Unauthorized();

            var ticketFromRepo = await _repo.GetTickets();

            //var ticketToReturn = _mapper.Map<Tickets>(ticketFromRepo);

            return Ok(ticketFromRepo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketForClient(int userId, /*string title, string description,*/ [FromForm]TicketForCreationDto ticketForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var clientFromRepo = await _repo.GetClient(userId);

            /* Tickets newTicket = new Tickets()
           {
                ticketForCreationDto.Title = title
                ticketForCreationDto.Description = description

           };*/



            var ticket = _mapper.Map<Tickets>(ticketForCreationDto);

            clientFromRepo.Tickets.Add(ticket);



            if (await _repo.SaveAll())
            {
                var ticketToReturn = _mapper.Map<TicketsForDetailedDto>(ticket);
                return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticketToReturn);
            }

            return BadRequest("Could not book ticket");


        }


        [HttpPost("{id}/setUrgent")]
        public async Task<IActionResult> SetTicketUrgent(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var clientFromRepo = await _repo.GetClient(userId);

            if (!clientFromRepo.Tickets.Any(t => t.Id == id))
                return Unauthorized();

            var ticketFromRepo = await _repo.GetTicket(id);

            if (ticketFromRepo.IsUrgent)
                return BadRequest("Ticket is already set as Urgent");

            ticketFromRepo.IsUrgent = true;

            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest("Could not set ticket to Urgrnt");




        }

        [HttpPost("{id}/setOpen")]
        public async Task<IActionResult> SetTicketOpen(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var clientFromRepo = await _repo.GetClient(userId);

            if (!clientFromRepo.Tickets.Any(t => t.Id == id))
                return Unauthorized();

            var ticketFromRepo = await _repo.GetTicket(id);

            if (ticketFromRepo.Open)
                return BadRequest("Ticket is already set as Open");

            ticketFromRepo.Open = true;

            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest("Could not set ticket to Open");


        }

    }
}