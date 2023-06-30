using AutoMapper;
using FlightSchoolTss.Data.DTOs.Configuration;
using FlightSchoolTss.Data.DTOs.ConfigurationItem;
using FlightSchoolTss.Data.DTOs.HardwareConfiguration;
using FlightSchoolTss.Data.DTOs.HardwareSystem;
using FlightSchoolTss.Data.DTOs.HardwareVersion;
using FlightSchoolTss.Data.DTOs.HardwareVersionsConfigurations;
using FlightSchoolTss.Data.DTOs.ItemTypes;
using FlightSchoolTss.Data.DTOs.Maintainable;
using FlightSchoolTss.Data.DTOs.SoftwareLoad;
using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using FlightSchoolTss.Data.DTOs.SoftwareVersion;
using FlightSchoolTss.Data.DTOs.SoftwareVersionLoad;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.ViewModels.Maintainer;
using FlightSchoolTss.DTOs.Lot;
using FlightSchoolTss.Data.DTOs.Maintainer;
using FlightSchoolTss.DTOs.ManModule;
using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Simulator;
using FlightSchoolTss.Data.ViewModels.Platform;
using FlightSchoolTss.Data.ViewModels.Generic;

namespace FlightSchoolTss.Data.Configurations;
public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ConfigurationItem, ConfigurationItemDto>().ReverseMap();

        CreateMap<Configuration, ConfigurationDto>().ReverseMap();

        CreateMap<HardwareConfiguration, HardwareConfigurationDto>().ReverseMap();

        CreateMap<HardwareSystem, HardwareSystemDto>().ReverseMap();

        CreateMap<HardwareVersion, HardwareVersionDto>().ReverseMap();

        CreateMap<HardwareVersionsConfigurations, HardwareVersionsConfigurationsDto>().ReverseMap();

        CreateMap<ItemType, ItemTypeDto>().ReverseMap();

        CreateMap<Maintainable, MaintainableDto>().ReverseMap();
        CreateMap<Maintainable, CreateMaintainableDto>().ReverseMap();

        CreateMap<Maintainer, MaintainerDto>().ReverseMap();
        CreateMap<Maintainer, CreateMaintainerDto>().ReverseMap();
        
        CreateMap<MaintainerDto, CreateMaintainerDto>()
            .ForMember(i => i.Id, x => x.MapFrom(dto => dto.Id))
            .ReverseMap();

        CreateMap<MaintainerDto, MaintainerVm>().ReverseMap();
        CreateMap<Maintainer, MaintainerDetailsDto>()
            .ForMember(i => i.Platforms, x => x.MapFrom(maintainer => maintainer.Platforms));

        CreateMap<ManModule, ManModuleDto>().ReverseMap();
        CreateMap<ManModule, CreateManModuleDto>().ReverseMap();

        CreateMap<Platform, PlatformDto>().ReverseMap();
        CreateMap<Platform, CreatePlatformDto>().ReverseMap();
        CreateMap<Platform, PlatformDetailsDto>()
            .ForMember(i => i.Simulators, x => x.MapFrom(platform => platform.Simulators));
        CreateMap<PlatformDto, RadioVm>().ReverseMap();

        CreateMap<PlatformDetailsDto, PlatformTableRowVm>()
            .ForMember(i => i.Maintainer, x => x.MapFrom(dto => dto.Maintainer.Name))
            .ForMember(i => i.MaintainerId, x => x.MapFrom(dto => dto.Maintainer.Id))
            .ReverseMap();

        CreateMap<PlatformTableRowVm, PlatformDto>().ReverseMap();

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