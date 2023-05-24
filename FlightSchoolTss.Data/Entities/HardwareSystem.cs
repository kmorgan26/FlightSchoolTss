using FlightSchoolTss.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace FlightSchoolTss.Data.Entities;

public partial class HardwareSystem : BaseEntity
{
    public int MaintainableId { get; set; }
    public virtual Maintainable Maintainable { get; set; } = null!;
    public virtual ICollection<HardwareVersion> HardwareVersions { get; set; } = new List<HardwareVersion>();
}
