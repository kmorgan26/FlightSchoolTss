﻿using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;

public interface ISoftwareVersionRepository : IGenericRepository<SoftwareVersion>
{
    Task<IEnumerable<SoftwareVersion>> GetSoftwareVersionsBySoftwareSystemIdAsync(int id);
}
