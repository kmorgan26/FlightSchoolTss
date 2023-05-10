using AutoMapper;
using WebApiTraining.Data.Entities;
using WebApiTraining.DTOs.Lot;
using WebApiTraining.DTOs.Maintainer;
using WebApiTraining.DTOs.ManModule;
using WebApiTraining.DTOs.Platform;
using WebApiTraining.DTOs.Simulator;

namespace WebApiTraining.Configurations;
public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Maintainer, MaintainerDto>().ReverseMap();
        CreateMap<Maintainer, CreateMaintainerDto>().ReverseMap();
        CreateMap<Maintainer, MaintainerDetailsDto>()
            .ForMember(i => i.Platforms, x => x.MapFrom(maintainer => maintainer.Platforms));

        CreateMap<ManModule, ManModuleDto>().ReverseMap();
        CreateMap<ManModule, CreateManModuleDto>().ReverseMap();

        CreateMap<Platform, PlatformDto>().ReverseMap();
        CreateMap<Platform, CreatePlatformDto>().ReverseMap();
        CreateMap<Platform, PlatformDetailsDto>()
            .ForMember(i => i.Simulators, x => x.MapFrom(platform => platform.Simulators));

        CreateMap<Simulator, SimulatorDto>().ReverseMap();
        CreateMap<Simulator, CreateSimulatorDto>().ReverseMap();

        CreateMap<Lot, LotDto>().ReverseMap();
        CreateMap<Lot, CreateLotDto>().ReverseMap();
        CreateMap<Lot, LotDetailsDto>()
            .ForMember(i => i.ManModules, x => x.MapFrom(lot => lot.ManModules));

    }
}