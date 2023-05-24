namespace FlightSchoolTss.Data.Entities;

public partial class HardwareVersionConfiguration
{
    public int Id { get; set; }

    public int HardwareVersionId { get; set; }

    public int HardwareConfigurationId { get; set; }

    public virtual HardwareConfiguration HardwareConfiguration { get; set; } = null!;

    public virtual HardwareVersion HardwareVersion { get; set; } = null!;
}
