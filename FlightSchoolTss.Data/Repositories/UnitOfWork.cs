using FlightSchoolTss.Data.Abstractions;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightSchoolTss.Data.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FstssDataContext _dbContext;
    private bool _disposed;

    public IMaintainerRepository Maintainers { get;private set; }
    public IPlatformRepository Platforms { get; private set; }
    public ILotRepository Lots { get; private set; }
    public ISimulatorRepository Simulators { get; private set; }
    public IManModuleRepository ManModules { get; private set; }

    public UnitOfWork(FstssDataContext dbContext)
    {
        _dbContext = dbContext;
        Maintainers = new MaintainerRepository(dbContext);
        Platforms = new PlatformRepository(dbContext);
        Lots = new LotRepository(dbContext);
        Simulators = new SimulatorRepository(dbContext);
        ManModules = new ManModuleRepository(dbContext);
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