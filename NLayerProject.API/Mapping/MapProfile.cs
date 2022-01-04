using AutoMapper;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Entities;

namespace NLayerProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }


    }
}
