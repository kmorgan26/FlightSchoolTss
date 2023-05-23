using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class HardwareSystemRepository : GenericRepository<HardwareSystem>, IHardwareSystemRepository
{
    public HardwareSystemRepository(FstssDataContext context) : base(context)
    {
    }
}
