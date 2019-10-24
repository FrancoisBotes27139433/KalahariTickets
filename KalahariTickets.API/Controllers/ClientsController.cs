using System.Threading.Tasks;
using AutoMapper;
using KalahariTickets.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using KalahariTickets.API.Dtos;
using System.Collections.Generic;
using System.Security.Claims;
using KalahariTickets.API.Models;
using System;
using System.Linq;

namespace KalahariTickets.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ClientsController : ControllerBase
    {
        private readonly IKalahariTicketsInterface _repo;
        private readonly IMapper _mapper;
        public ClientsController(IKalahariTicketsInterface repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _repo.GetClients();

           var clientsToReturn = _mapper.Map<IEnumerable<ClientForListDto>>(clients);

            return Ok(clientsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _repo.GetClient(id);

           var clientToReturn = _mapper.Map<ClientForDetailedDto>(client);

            return Ok(clientToReturn);
        }

        [HttpGet("tickets")]

        public async Task<IActionResult> GetTickets()
        {

            var tickets = await _repo.GetTickets();

            if(tickets == null)
                return BadRequest("Could not load all tickets");

            return Ok(tickets);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientForUpdateDto clientForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var clientFromRepo = await _repo.GetClient(id);

            _mapper.Map(clientForUpdateDto, clientFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating client {id} failed at save");
        }

        
        [HttpDelete(("{userId}"))]
        public async Task<IActionResult> DeleteClient(int userId)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var client= await _repo.GetClient(userId);

           // if(!client.Tickets.Any(p => p.Id == id))
              //  return Unauthorized();

           // var ClienttFromRepo = await _repo.Get(id);

           // var deleteParams = new DeletionParams(ticketFromRepo.Id);

           _repo.Delete(client);

            if(await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete ticket");

        }



    }
}