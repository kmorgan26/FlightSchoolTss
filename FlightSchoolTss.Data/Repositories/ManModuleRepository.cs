﻿using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;

namespace FlightSchoolTss.Data.Repositories;
public class ManModuleRepository : GenericRepository<ManModule>, IManModuleRepository
{
    public ManModuleRepository(FstssDataContext context) : base(context)
    {
    }
}