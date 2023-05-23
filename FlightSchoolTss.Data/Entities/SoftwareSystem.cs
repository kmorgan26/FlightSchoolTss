using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;

public partial class SoftwareSystem : BaseEntity
{
    public virtual ICollection<SoftwareVersion> SoftwareVersions { get; set; } = new List<SoftwareVersion>();
}
