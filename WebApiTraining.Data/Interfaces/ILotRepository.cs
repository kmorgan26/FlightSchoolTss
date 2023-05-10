using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Interfaces;
public interface ILotRepository : IGenericRepository<Lot>
{
    Task<IEnumerable<Lot>> GetLotsWithManModuleDetailsByIdAsync(int lotId);
}