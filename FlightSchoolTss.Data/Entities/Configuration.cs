using System;
using System.Collections.Generic;

namespace FlightSchoolTss.Data.Entities;

public partial class Configuration 
{
    public int Id { get; set; }

    public int ConfigurationItemId { get; set; }

    public int MaintainableId { get; set; }

    public virtual ConfigurationItem ConfigurationItem { get; set; } = null!;

    public virtual Maintainable Maintainable { get; set; } = null!;
}
