using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class ItemTypeRepository : GenericRepository<ItemType>, IItemTypeRepository
{
    public ItemTypeRepository(FstssDataContext context) : base(context)
    {
    }
}
