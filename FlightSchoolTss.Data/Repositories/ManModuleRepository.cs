using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightSchoolTss.Data.Repositories;
public class ManModuleRepository : GenericRepository<ManModule>, IManModuleRepository
{
    public ManModuleRepository(FstssDataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ManModule>> GetManModulesByLotIdAsync(int id)
    {
        return await _context.ManModules
            .Where(s => s.LotId == id)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}