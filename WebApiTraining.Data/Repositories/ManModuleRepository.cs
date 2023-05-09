using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;
public class ManModuleRepository : GenericRepository<ManModule>, IManModuleRepository
{
    public ManModuleRepository(FstssDataContext context) : base(context)
    {
    }
}
