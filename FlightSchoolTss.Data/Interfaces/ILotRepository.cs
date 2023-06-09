﻿using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Interfaces;
public interface ILotRepository : IGenericRepository<Lot>
{
    Task<IEnumerable<Lot>> GetLotsWithManModuleDetailsByIdAsync(int lotId);
}