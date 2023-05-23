using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class ConfigurationItemRepository : GenericRepository<ConfigurationItem>, IConfigurationItemRepository
{
    public ConfigurationItemRepository(FstssDataContext context) : base(context)
    {
    }
}
