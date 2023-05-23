using FlightSchoolTss.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace FlightSchoolTss.Data.Entities;

public partial class HardwareSystem : BaseEntity
{
    public virtual ICollection<HardwareVersion> HardwareVersions { get; set; } = new List<HardwareVersion>();
}
