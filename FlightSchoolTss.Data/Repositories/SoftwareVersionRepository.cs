using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class SoftwareVersionRepository : GenericRepository<SoftwareVersion>, ISoftwareVersionRepository
{
    public SoftwareVersionRepository(FstssDataContext context) : base(context)
    {
    }
}