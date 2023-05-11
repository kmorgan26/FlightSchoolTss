using FlightSchoolTss.Data.Entities;

namespace FlightSchoolTss.Data.Interfaces;
public interface IPlatformRepository : IGenericRepository<Platform>
{
    Task<IEnumerable<Platform>> GetPlatformsByMaintainerIdAsync(int maintainerId);
    Task<IEnumerable<Platform>> GetPlatformsWithSimulatorDetailsAsync();
}