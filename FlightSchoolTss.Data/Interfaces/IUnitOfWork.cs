using FlightSchoolTss.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchoolTss.Data.Interfaces;
public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rollback();
    IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity;

    IMaintainerRepository Maintainers { get; }
    IPlatformRepository Platforms { get; }
    ILotRepository Lots { get; }
    ISimulatorRepository Simulators { get; }

}
