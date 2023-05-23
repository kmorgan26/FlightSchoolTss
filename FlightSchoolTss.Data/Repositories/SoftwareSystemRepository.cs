using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class SoftwareSystemRepository : GenericRepository<SoftwareSystem>, ISoftwareSystemRepository
{
    public SoftwareSystemRepository(FstssDataContext context) : base(context)
    {
    }
}
