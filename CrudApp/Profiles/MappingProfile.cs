using AutoMapper;
using CrudApp.Application.DTOs;
using CrudApp.Domain.Models;

namespace CrudApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, GetBrandDto>().ReverseMap(); 
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
        }
    }
}
