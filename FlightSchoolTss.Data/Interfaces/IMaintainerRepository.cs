﻿using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface IMaintainerRepository : IGenericRepository<Maintainer>
{
    Task<IEnumerable<Maintainer>> GetMaintainersWithPlatformDetailsAsync();
}
