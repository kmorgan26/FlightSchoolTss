using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;

public partial class SoftwareVersion : BaseEntity
{
    public DateTime VersionDate { get; set; }

    public int SoftwareSystemId { get; set; }

    public virtual SoftwareSystem SoftwareSystem { get; set; } = null!;

    public virtual ICollection<SoftwareVersionLoad> SoftwareVersionsLoads { get; set; } = new List<SoftwareVersionLoad>();
}
