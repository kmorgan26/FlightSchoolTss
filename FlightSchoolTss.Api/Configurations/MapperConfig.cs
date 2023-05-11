using AutoMapper;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.DTOs.Lot;
using FlightSchoolTss.DTOs.Maintainer;
using FlightSchoolTss.DTOs.ManModule;
using FlightSchoolTss.DTOs.Platform;
using FlightSchoolTss.DTOs.Simulator;

namespace FlightSchoolTss.Configurations;
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