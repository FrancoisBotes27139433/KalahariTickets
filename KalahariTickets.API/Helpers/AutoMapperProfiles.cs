using AutoMapper;
using KalahariTickets.API.Dtos;
using KalahariTickets.API.Models;

namespace KalahariTickets.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Client, ClientForListDto>();
            CreateMap<Client, ClientForDetailedDto>();
            CreateMap<Tickets, TicketsForDetailedDto>();
            CreateMap<ClientForUpdateDto, Client>();
            
        }
    }
}