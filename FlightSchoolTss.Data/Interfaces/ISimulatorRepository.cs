using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface ISimulatorRepository : IGenericRepository<Simulator>
{
    Task<IEnumerable<Simulator>> GetSimulatorsByPlatformIdAsync(int platformId);
    Task<IEnumerable<Simulator>> GetSimulatorsWithPlatformsAsync();
}