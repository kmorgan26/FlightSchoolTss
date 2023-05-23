using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;

public partial class SoftwareLoad : BaseEntity
{
    public int ConfigurationItemId { get; set; }

    public virtual ConfigurationItem ConfigurationItem { get; set; } = null!;

    public virtual ICollection<SoftwareVersionsLoad> SoftwareVersionsLoads { get; set; } = new List<SoftwareVersionsLoad>();
}
