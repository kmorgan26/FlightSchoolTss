using Microsoft.EntityFrameworkCore;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class SimulatorRepository : GenericRepository<Simulator>, ISimulatorRepository
{
    public SimulatorRepository(FstssDataContext context) : base(context){}
    public async Task<IEnumerable<Simulator>> GetAllSimulatorsByPlatformIdAsync(int platformId)
    {
        return await _context.Simulators
            .Where(s => s.PlatformId == platformId)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}