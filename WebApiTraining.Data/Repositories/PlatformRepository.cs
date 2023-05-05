using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;
public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
{
    public PlatformRepository(FstssDataContext context) : base(context)
    {
        
    }
}
