using System.Collections.Generic;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Interfaces;
public interface ISimulatorRepository : IGenericRepository<Simulator>
{
    Task<IEnumerable<Simulator>> GetAllSimulatorsByPlatformIdAsync(int platformId);
}
