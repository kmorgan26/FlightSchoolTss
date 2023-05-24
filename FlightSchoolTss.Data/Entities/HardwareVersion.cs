using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;

public partial class HardwareVersion : BaseEntity
{
    public int HardwareSystemId { get; set; }

    public DateTime VersionDate { get; set; }

    public virtual HardwareSystem HardwareSystem { get; set; } = null!;

    public virtual ICollection<HardwareVersionsConfigurations> HardwareVersionsConfigurations { get; set; } = new List<HardwareVersionsConfigurations>();
}
