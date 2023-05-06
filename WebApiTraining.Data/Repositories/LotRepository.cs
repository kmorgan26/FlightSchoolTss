using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;
public class LotRepository : GenericRepository<Lot>, ILotRepository
{
    public LotRepository(FstssDataContext context) : base(context)
    {
    }
}