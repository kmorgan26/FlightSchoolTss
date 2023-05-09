using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;
public class MaintainerRepository : GenericRepository<Maintainer>, IMaintainerRepository
{
    public MaintainerRepository(FstssDataContext context) : base(context) { }

    public async Task<IEnumerable<Maintainer>> GetMaintainersWithPlatformDetailsAsync()
    {
        return await _context.Maintainers
            .Include(i => i.Platforms)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}
