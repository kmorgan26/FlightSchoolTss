using Microsoft.EntityFrameworkCore;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;
public class LotRepository : GenericRepository<Lot>, ILotRepository
{
    public LotRepository(FstssDataContext context) : base(context){}

    public async Task<IEnumerable<Lot>> GetLotsWithManModuleDetailsByIdAsync(int lotId)
    {
        return await _context.Lots
            .Include(i => i.ManModules)
            .Where(l => l.Id == lotId)
            .ToListAsync();
    }
}