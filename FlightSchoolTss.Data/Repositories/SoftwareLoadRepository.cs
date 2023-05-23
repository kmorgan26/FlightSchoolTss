using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class SoftwareLoadRepository : GenericRepository<SoftwareLoad>, ISoftwareLoadRepository
{
    public SoftwareLoadRepository(FstssDataContext context) : base(context)
    {
    }
}
