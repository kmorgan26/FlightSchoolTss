using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;

public interface ISoftwareSystemRepository : IGenericRepository<SoftwareSystem>
{
    Task<IEnumerable<SoftwareSystem>> GetSoftwareSystemsByMaintainableIdAsync(int id);
}
