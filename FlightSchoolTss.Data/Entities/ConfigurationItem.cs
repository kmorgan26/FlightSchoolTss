using FlightSchoolTss.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace FlightSchoolTss.Data.Entities;

public partial class ConfigurationItem : BaseEntity
{
    public int ItemTypeId { get; set; }

    public virtual ItemType ItemType { get; set; } = null!;

    public virtual ICollection<Configuration> Configurations { get; set; } = new List<Configuration>();

    public virtual ICollection<HardwareConfiguration> HardwareConfigurations { get; set; } = new List<HardwareConfiguration>();

    public virtual ICollection<SoftwareLoad> SoftwareLoads { get; set; } = new List<SoftwareLoad>();
}