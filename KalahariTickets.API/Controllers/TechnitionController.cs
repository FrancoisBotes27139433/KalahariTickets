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

namespace KalahariTickets.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnitionController : ControllerBase
    {
        private readonly IKalahariTicketsInterface _repo;
        private readonly IMapper _mapper;
        public TechnitionController(IKalahariTicketsInterface repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetTechnitions()
        {
            var technitions = await _repo.GetTechnitions();

            var technitionsToReturn = _mapper.Map<IEnumerable<TechnitionForListDto>>(technitions);

            return Ok(technitionsToReturn);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnition(int id)
        {
            var technition = await _repo.GetTechnition(id);

           //var technitionToReturn = _mapper.Map<Technition>(technition);

            return Ok(technition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnition(int id, TechnitionForListDto technitionForListDto)
        {
            //if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                //return Unauthorized();

            var technitionFromRepo = await _repo.GetTechnition(id);

            _mapper.Map(technitionForListDto, technitionFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating client {id} failed at save");
        }

        [HttpPost("AddTechnition")]

        public async Task<IActionResult> AddTechnition([FromForm]TechnitionForRegisterDto technitionForRegisterDto)
        {
            // validate reguest 

           technitionForRegisterDto.FirstName = technitionForRegisterDto.FirstName.ToLower();
           technitionForRegisterDto.LastName = technitionForRegisterDto.LastName.ToLower();
            //technitionForRegisterDto.MonthlySalary = technitionForRegisterDto.MonthlySalary;
           // technitionForRegisterDto.Age = technitionForRegisterDto.Age;

            if (await _repo.TechnitionExists(technitionForRegisterDto.FirstName))
                return BadRequest("Technition already exists");

            var technician = new Technition
            {
                FirstName = technitionForRegisterDto.FirstName,
                LastName = technitionForRegisterDto.LastName,
                MonthlySalary = technitionForRegisterDto.MonthlySalary,
                Age = technitionForRegisterDto.Age
            };

             _repo.Add(technician);



            //var ticket = _mapper.Map<Tickets>(ticketForCreationDto);

           //technitionForRegisterDto.Technition.Add(ticket);

            //technitionForRegisterDto = await _repo.Add(TechnitionToCreate);
            if (await _repo.SaveAll())
                return StatusCode(201);
            
            throw new Exception($"Technition could not be added");
            
        }
    }
}