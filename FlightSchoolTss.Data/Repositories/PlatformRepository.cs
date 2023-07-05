using Microsoft.EntityFrameworkCore;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;
public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
{
    public PlatformRepository(FstssDataContext context) : base(context){}

    public async Task<IEnumerable<Platform>> GetPlatformsByMaintainerIdAsync(int maintainerId)
    {
        return await _context.Platforms
            .Where(s => s.MaintainerId == maintainerId)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Platform>> GetPlatformsWithSimulatorDetailsAsync()
    {
        return await _context.Platforms
            .Include(i => i.Simulators)
            .OrderBy (s => s.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Platform>> GetPlatformDtos()
    {
        return await _context.Platforms
            .Include(i => i.Maintainer)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}