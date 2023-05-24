using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;

public class SoftwareVersionsLoadsRepository : AnonymousRepository<SoftwareVersionsLoad>, ISoftwareVersionsLoadsRepository
{
    public SoftwareVersionsLoadsRepository(FstssDataContext context) : base(context)
    {       
    }
}