using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface IPlatformRepository : IGenericRepository<Platform>
{
    Task<IEnumerable<Platform>> GetPlatformsByMaintainerIdAsync(int maintainerId);
    Task<IEnumerable<Platform>> GetPlatformsWithSimulatorDetailsAsync();
}