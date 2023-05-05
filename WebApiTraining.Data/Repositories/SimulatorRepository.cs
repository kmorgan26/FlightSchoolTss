using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;

public class SimulatorRepository : GenericRepository<Simulator>, ISimulatorRepository
{
    public SimulatorRepository(FstssDataContext context) : base(context)
    {

    }
    public async Task<IEnumerable<Simulator>> GetAllSimulatorsByPlatformIdAsync(int platformId)
    {
        return await _context.Simulators
            .Where(s => s.PlatformId == platformId)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}
