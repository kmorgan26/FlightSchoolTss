using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface ISimulatorRepository : IGenericRepository<Simulator>
{
    Task<IEnumerable<Simulator>> GetAllSimulatorsByPlatformIdAsync(int platformId);
}