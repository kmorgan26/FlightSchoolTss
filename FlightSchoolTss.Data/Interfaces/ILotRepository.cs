using FlightSchoolTss.Data.Entities;

namespace FlightSchoolTss.Data.Interfaces;
public interface ILotRepository : IGenericRepository<Lot>
{
    Task<IEnumerable<Lot>> GetLotsWithManModuleDetailsByIdAsync(int lotId);
}