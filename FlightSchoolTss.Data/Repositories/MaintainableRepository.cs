using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class MaintainableRepository : GenericRepository<Maintainable>, IMaintainableRepository
{
    public MaintainableRepository(FstssDataContext context): base(context) { }
}