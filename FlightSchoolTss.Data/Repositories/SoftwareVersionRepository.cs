using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightSchoolTss.Data.Repositories;

public class SoftwareVersionRepository : GenericRepository<SoftwareVersion>, ISoftwareVersionRepository
{
    public SoftwareVersionRepository(FstssDataContext context) : base(context)
    {
    }
    public async Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsBySoftwareSystemIdAsync(int softwareSystemId)
    {
        return await _context.SoftwareVersions
            .Where(i => i.SoftwareSystemId == softwareSystemId)
            .OrderBy(i => i.Name)
            .ToListAsync();
    }
}