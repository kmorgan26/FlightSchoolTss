using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class HardwareVersionsConfigurationRepository : AnonymousRepository<HardwareVersionsConfigurations> , IHardwareVersionsConfigurationsRepository
{
    public HardwareVersionsConfigurationRepository(FstssDataContext context) : base(context)
    {
    }
}