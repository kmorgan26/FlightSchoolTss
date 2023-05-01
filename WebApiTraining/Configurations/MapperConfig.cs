using AutoMapper;
using WebApiTraining.Data.Entities;
using WebApiTraining.DTOs.Maintainer;
using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Maintainer, MaintainerDto>().ReverseMap();
        CreateMap<Maintainer, CreateMaintainerDto>().ReverseMap();

        CreateMap<Platform, PlatformDto>().ReverseMap();
        CreateMap<Platform, CreatePlatformDto>().ReverseMap();

    }
}
