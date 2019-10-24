using System.Threading.Tasks;
using AutoMapper;
using KalahariTickets.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KalahariTickets.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AllTicketController : ControllerBase
    {
         private readonly IKalahariTicketsInterface _repo;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AllTicketController(IKalahariTicketsInterface repo, IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]

        public async Task<IActionResult> GetTickets()
        {

            var tickets = await _repo.GetTickets();

            if(tickets == null)
                return BadRequest("Could not load all tickets");

            return Ok(tickets);

        }
    }
}
