using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface IManModuleRepository : IGenericRepository<ManModule>
{
    Task<IEnumerable<ManModule>> GetManModulesByLotIdAsync(int id);
}