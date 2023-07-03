using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightSchoolTss.Data.Repositories;

public class SoftwareSystemRepository : GenericRepository<SoftwareSystem>, ISoftwareSystemRepository
{
    public SoftwareSystemRepository(FstssDataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<SoftwareSystem>> GetSoftwareSystemsByMaintainableIdAsync(int maintainableId)
    {
        return await _context.SoftwareSystems
            .Where(i => i.MaintainableId == maintainableId)
            .OrderBy(i => i.Name)
            .ToListAsync();
    }
}
