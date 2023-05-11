using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;
public class ManModuleRepository : GenericRepository<ManModule>, IManModuleRepository
{
    public ManModuleRepository(FstssDataContext context) : base(context)
    {
    }
}
