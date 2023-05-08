using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;
public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
{
    public PlatformRepository(FstssDataContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Platform>> GetAllPlatformsByMaintainerIdAsync(int maintainerId)
    {
        return await _context.Platforms
            .Where(s => s.MaintainerId == maintainerId)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}
