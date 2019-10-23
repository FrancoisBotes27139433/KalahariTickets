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
            CreateMap<Tickets, TicketsForDetailedDto>();
            CreateMap<TicketForCreationDto, Tickets>();
           // CreateMap<TicketsForDetailedDto, Tickets>();
            CreateMap<Technition, TechnitionForListDto>();
            CreateMap<TechnitionForListDto, Technition>();
            CreateMap<TechnitionForRegisterDto, Technition>();

            CreateMap<TicketsForDetailedDto, Tickets>().ForMember(src => src.Notes, opt => opt.Ignore())
                .ForMember(src => src.Description, opt => opt.Ignore())
                .ForMember(src => src.DateClossed, opt => opt.Ignore())
                .ForMember(src => src.DateIssued, opt => opt.Ignore())
                .ForMember(src => src.IsUrgent, opt => opt.Ignore())
                .ForMember(src => src.Title, opt => opt.Ignore());
                        
        }
    }
}