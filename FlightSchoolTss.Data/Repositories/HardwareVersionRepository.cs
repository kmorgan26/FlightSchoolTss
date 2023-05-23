using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class HardwareVersionRepository : GenericRepository<HardwareVersion>, IHardwareVersionRepository
{
    public HardwareVersionRepository(FstssDataContext context) : base(context)
    {
    }
}
