using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class ConfigurationRepository : AnonymousRepository<Configuration>, IConfigurationRepository
{
    public ConfigurationRepository(FstssDataContext context) : base (context)
    {
        
    }
}
