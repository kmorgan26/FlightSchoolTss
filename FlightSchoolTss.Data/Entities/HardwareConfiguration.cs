﻿using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;

public partial class HardwareConfiguration : BaseEntity
{
    public int ConfigurationItemId { get; set; }

    public virtual ConfigurationItem ConfigurationItem { get; set; } = null!;

    public virtual ICollection<HardwareVersionsConfiguration> HardwareVersionsConfigurations { get; set; } = new List<HardwareVersionsConfiguration>();
}