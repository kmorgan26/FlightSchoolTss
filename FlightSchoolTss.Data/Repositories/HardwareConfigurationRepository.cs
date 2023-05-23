using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class HardwareConfigurationRepository : GenericRepository<HardwareConfiguration>, IHardwareConfigurationRepository
{
    public HardwareConfigurationRepository(FstssDataContext context) : base(context)
    {
    }
}
