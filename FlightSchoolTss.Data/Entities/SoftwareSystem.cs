using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;

public partial class SoftwareSystem : BaseEntity
{
    public int MaintainableId { get; set; }
    public virtual Maintainable Maintainable { get; set; } = null!;
    public virtual ICollection<SoftwareVersion> SoftwareVersions { get; set; } = new List<SoftwareVersion>();
}
