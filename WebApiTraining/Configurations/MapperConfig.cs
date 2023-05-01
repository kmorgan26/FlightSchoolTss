using AutoMapper;
using WebApiTraining.Data.Entities;
using WebApiTraining.DTOs.Maintainer;

namespace WebApiTraining.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Maintainer, MaintainerDto>().ReverseMap();
        CreateMap<Maintainer, CreateMaintainerDto>().ReverseMap();
    }
}
