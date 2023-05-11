using FlightSchoolTss.Data.Entities;

namespace FlightSchoolTss.Data.Interfaces;
public interface IMaintainerRepository : IGenericRepository<Maintainer>
{
    Task<IEnumerable<Maintainer>> GetMaintainersWithPlatformDetailsAsync();
}