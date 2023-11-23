using AutoMapper;
using PartyProductWebApi.DTOs;
using PartyProductWebApi.Models;

namespace PartyProductWebApi.Helpers
{
    public class ApplicationMappers : Profile
    {
        public ApplicationMappers()
        {
            CreateMap<Party, PartyDTO>().ReverseMap();
            CreateMap<PartyCreationDTO, Party>();

        }
    }
}
