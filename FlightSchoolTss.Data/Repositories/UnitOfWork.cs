using FlightSchoolTss.Data.Abstractions;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FstssDataContext _dbContext;
    private bool _disposed;

    public IConfigurationItemRepository ConfigurationItems { get; private set; }
    public IHardwareConfigurationRepository HardwareConfigurations { get; private set; }
    public IHardwareSystemRepository HardwareSystems { get; private set; }
    public IHardwareVersionRepository HardwareVersions { get; private set; }
    public IItemTypeRepository ItemTypes { get; private set; }
    public ILotRepository Lots { get; private set; }
    public IMaintainerRepository Maintainers { get;private set; }
    public IManModuleRepository ManModules { get; private set; }
    public IPlatformRepository Platforms { get; private set; }
    public ISimulatorRepository Simulators { get; private set; }
    public ISoftwareLoadRepository SoftwareLoads { get; private set; }
    public ISoftwareSystemRepository SoftwareSystems { get; private set; }
    public ISoftwareVersionRepository SoftwareVersions { get; private set; }


    public UnitOfWork(FstssDataContext dbContext)
    {
        _dbContext = dbContext;
        ConfigurationItems = new ConfigurationItemRepository(dbContext);
        HardwareConfigurations = new HardwareConfigurationRepository(dbContext);
        HardwareSystems = new HardwareSystemRepository(dbContext);
        HardwareVersions = new HardwareVersionRepository(dbContext);
        ItemTypes = new ItemTypeRepository(dbContext);
        Lots = new LotRepository(dbContext);
        Maintainers = new MaintainerRepository(dbContext);
        ManModules = new ManModuleRepository(dbContext);
        Platforms = new PlatformRepository(dbContext);
        Simulators = new SimulatorRepository(dbContext);
        SoftwareLoads = new SoftwareLoadRepository(dbContext);
        SoftwareSystems = new SoftwareSystemRepository(dbContext);
        SoftwareVersions = new SoftwareVersionRepository(dbContext);

    }
    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    public void Rollback()
    {
        foreach(var entry in _dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }
    public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity
    {
        return new GenericRepository<TEntity>(_dbContext);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if(disposing)
                _dbContext?.Dispose();
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}