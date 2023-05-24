using AutoMapper;
using FlightSchoolTss.Api.DTOs.Configuration;
using FlightSchoolTss.Api.DTOs.ConfigurationItem;
using FlightSchoolTss.Api.DTOs.HardwareConfiguration;
using FlightSchoolTss.Api.DTOs.HardwareSystem;
using FlightSchoolTss.Api.DTOs.HardwareVersion;
using FlightSchoolTss.Api.DTOs.HardwareVersionConfiguration;
using FlightSchoolTss.Api.DTOs.ItemTypes;
using FlightSchoolTss.Api.DTOs.Maintainable;
using FlightSchoolTss.Api.DTOs.SoftwareLoad;
using FlightSchoolTss.Api.DTOs.SoftwareSystem;
using FlightSchoolTss.Api.DTOs.SoftwareVersion;
using FlightSchoolTss.Api.DTOs.SoftwareVersionLoad;
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
        CreateMap<ConfigurationItem, ConfigurationItemDto>().ReverseMap();
        CreateMap<ConfigurationItem, CreateConfigurationItemDto>().ReverseMap();

        CreateMap<Configuration, ConfigurationDto>().ReverseMap();
        CreateMap<Configuration, CreateConfigurationDto>().ReverseMap();

        CreateMap<HardwareConfiguration, HardwareConfigurationDto>().ReverseMap();
        CreateMap<HardwareConfiguration, CreateHardwareConfigurationDto>().ReverseMap();

        CreateMap<HardwareSystem, HardwareSystemDto>().ReverseMap();
        CreateMap<HardwareSystem, CreateHardwareSystemDto>().ReverseMap();

        CreateMap<HardwareVersion, HardwareVersionDto>().ReverseMap();
        CreateMap<HardwareVersion, CreateHardwareVersionDto>().ReverseMap();

        CreateMap<HardwareVersionConfiguration, HardwareVersionConfigurationDto>().ReverseMap();
        CreateMap<HardwareVersionConfiguration, CreateHardwareVersionConfigurationDto>().ReverseMap();

        CreateMap<ItemType, ItemTypeDto>().ReverseMap();
        CreateMap<ItemType, CreateItemTypeDto>().ReverseMap();

        CreateMap<Maintainable, MaintainableDto>().ReverseMap();
        CreateMap<Maintainable, CreateMaintainableDto>().ReverseMap();

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

        CreateMap<SoftwareLoad, SoftwareLoadDto>().ReverseMap();
        CreateMap<SoftwareLoad, CreateSoftwareLoadDto>().ReverseMap();

        CreateMap<SoftwareSystem, SoftwareSystemDto>().ReverseMap();
        CreateMap<SoftwareSystem, CreateSoftwareSystemDto>().ReverseMap();

        CreateMap<SoftwareVersion, SoftwareVersionDto>().ReverseMap();
        CreateMap<SoftwareVersion, CreateSoftwareVersionDto>().ReverseMap();

        CreateMap<SoftwareVersionLoad, SoftwareVersionLoadDto>().ReverseMap();
        CreateMap<SoftwareVersionLoad, CreateSoftwareVersionLoadDto>().ReverseMap();

        CreateMap<Lot, LotDto>().ReverseMap();
        CreateMap<Lot, CreateLotDto>().ReverseMap();
        CreateMap<Lot, LotDetailsDto>()
            .ForMember(i => i.ManModules, x => x.MapFrom(lot => lot.ManModules));

    }
}