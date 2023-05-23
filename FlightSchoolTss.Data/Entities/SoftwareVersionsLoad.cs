namespace FlightSchoolTss.Data.Entities;

public partial class SoftwareVersionsLoad
{
    public int Id { get; set; }

    public int SoftwareVersionId { get; set; }

    public int SoftwareLoadId { get; set; }

    public virtual SoftwareLoad SoftwareLoad { get; set; } = null!;

    public virtual SoftwareVersion SoftwareVersion { get; set; } = null!;
}
