﻿using AutoMapper;
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
using FlightSchoolTss.Data.DTOs.Lot;
using FlightSchoolTss.Data.DTOs.Maintainer;
using FlightSchoolTss.Data.DTOs.ManModule;
using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Simulator;
using FlightSchoolTss.Data.ViewModels.Generic;

namespace FlightSchoolTss.Data.Configurations;
public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Configuration, ConfigurationDto>().ReverseMap();

        CreateMap<ConfigurationItem, ConfigurationItemDto>().ReverseMap();

        CreateMap<HardwareConfiguration, HardwareConfigurationDto>().ReverseMap();

        CreateMap<HardwareSystem, HardwareSystemDto>().ReverseMap();

        CreateMap<HardwareVersion, HardwareVersionDto>().ReverseMap();

        CreateMap<HardwareVersionsConfigurations, HardwareVersionsConfigurationsDto>().ReverseMap();

        CreateMap<ItemType, ItemTypeDto>().ReverseMap();

        CreateMap<Maintainable, MaintainableDto>().ReverseMap();

        CreateMap<Maintainer, MaintainerDto>().ReverseMap();

        CreateMap<Maintainer, MaintainerDetailsDto>()
            .ForMember(dto => dto.Platforms, x => x.MapFrom(maintainer => maintainer.Platforms));

        CreateMap<ManModule, ManModuleDto>().ReverseMap();

        CreateMap<Platform, PlatformDto>();

        CreateMap<PlatformDto, Platform>()
            .ForMember(dto => dto.Maintainer, x => x.Ignore());

        CreateMap<Platform, PlatformDetailsDto>()
            .ForMember(dto => dto.Simulators, x => x.MapFrom(platform => platform.Simulators));

        CreateMap<PlatformDto, RadioVm>()
            .ForMember(radio => radio.Id, x => x.MapFrom(platform => platform.MaintainableId));

        CreateMap<PlatformDetailsDto, PlatformDto>()
            .ForMember(row => row.Maintainer, x => x.MapFrom(dto => dto.Maintainer.Name))
            .ForMember(row => row.MaintainerId, x => x.MapFrom(dto => dto.Maintainer.Id))
            .ReverseMap();

        CreateMap<Simulator, SimulatorDto>()
            .ForMember(dto => dto.Platform, x => x.MapFrom(entity => entity.Platform.Name));

        CreateMap<SimulatorDto, RadioVm>()
            .ForMember(radio => radio.Id, x => x.MapFrom(entity => entity.MaintainableId));

        CreateMap<SimulatorDto,Simulator>()
            .ForMember(dto => dto.Platform, ent => ent.Ignore());


        CreateMap<SoftwareLoad, SoftwareLoadDto>().ReverseMap();

        CreateMap<SoftwareSystem, SoftwareSystemDto>().ReverseMap();

        CreateMap<SoftwareVersion, SoftwareVersionDto>().ReverseMap();

        CreateMap<SoftwareVersionLoad, SoftwareVersionLoadDto>().ReverseMap();

        CreateMap<Lot, LotDto>().ReverseMap();
        CreateMap<Lot, LotDetailsDto>()
            .ForMember(dto => dto.ManModules, x => x.MapFrom(lot => lot.ManModules));

    }
}