using FlightSchoolTss.Data.Abstractions;
using System;
using System.Collections.Generic;

namespace FlightSchoolTss.Data.Entities;

public partial class ItemType : BaseEntity
{
    public virtual ICollection<ConfigurationItem> ConfigurationItems { get; set; } = new List<ConfigurationItem>();
}
