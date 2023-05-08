using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Interfaces;
public interface IPlatformRepository : IGenericRepository<Platform>
{
    Task<IEnumerable<Platform>> GetAllPlatformsByMaintainerIdAsync(int maintainerId);
    Task<IEnumerable<Platform>> GetPlatformsWithSimulatorDetailsAsync();
}
