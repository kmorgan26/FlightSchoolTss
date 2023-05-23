using FlightSchoolTss.Data.Abstractions;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    void Rollback();
    IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity;

    IMaintainerRepository Maintainers { get; }
    IPlatformRepository Platforms { get; }
    ILotRepository Lots { get; }
    ISimulatorRepository Simulators { get; }
    IManModuleRepository ManModules { get; }

}
