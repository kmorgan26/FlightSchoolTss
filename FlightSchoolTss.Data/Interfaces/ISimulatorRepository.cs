using FlightSchoolTss.Data.Entities;

namespace FlightSchoolTss.Data.Interfaces;
public interface ISimulatorRepository : IGenericRepository<Simulator>
{
    Task<IEnumerable<Simulator>> GetAllSimulatorsByPlatformIdAsync(int platformId);
}