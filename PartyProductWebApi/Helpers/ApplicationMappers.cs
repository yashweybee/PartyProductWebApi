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

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductCreationDTO, Product>();

            //CreateMap<Product, ProductRate>().ReverseMap();
            CreateMap<ProductRateCreationDTO, ProductRate>();
            CreateMap<ProductRate, ProductRateDTO>().ReverseMap();
        }
    }
}
