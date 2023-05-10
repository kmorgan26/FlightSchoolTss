using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;
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