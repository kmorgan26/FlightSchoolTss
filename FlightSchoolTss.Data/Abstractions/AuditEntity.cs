namespace FlightSchoolTss.Data.Abstractions;
public abstract class AuditEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = null!;
    public DateTime? LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; } = null!;
}