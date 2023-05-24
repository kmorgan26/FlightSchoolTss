using FlightSchoolTss.Data.Abstractions;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    void Rollback();
    IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity;

    IConfigurationItemRepository ConfigurationItems { get; }
    IConfigurationRepository Configurations { get; }
    IHardwareConfigurationRepository HardwareConfigurations { get; }
    IHardwareSystemRepository HardwareSystems { get; }  
    IHardwareVersionRepository HardwareVersions { get; }
    IHardwareVersionsConfigurationsRepository HardwareVersionsConfigurations { get; }
    IItemTypeRepository ItemTypes { get; }
    ILotRepository Lots { get; }
    IMaintainableRepository Maintainables { get; }
    IMaintainerRepository Maintainers { get; }
    IManModuleRepository ManModules { get; }
    IPlatformRepository Platforms { get; }
    ISimulatorRepository Simulators { get; }
    ISoftwareSystemRepository SoftwareSystems { get; }
    ISoftwareLoadRepository SoftwareLoads { get; }
    ISoftwareVersionRepository SoftwareVersions { get; }
    ISoftwareVersionsLoadsRepository SoftwareVersionsLoads { get; }
}
