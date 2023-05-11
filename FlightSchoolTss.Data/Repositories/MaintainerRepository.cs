using Microsoft.EntityFrameworkCore;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;
public class MaintainerRepository : GenericRepository<Maintainer>, IMaintainerRepository
{
    public MaintainerRepository(FstssDataContext context) : base(context) { }

    public async Task<IEnumerable<Maintainer>> GetMaintainersWithPlatformDetailsAsync()
    {
        return await _context.Maintainers
            .Include(i => i.Platforms)
            .ThenInclude(i => i.Simulators)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}
