using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;
public class MaintainerRepository : GenericRepository<Maintainer>, IMaintainerRepository
{
    public MaintainerRepository(FstssDataContext context) : base(context)
    {
    }
}
