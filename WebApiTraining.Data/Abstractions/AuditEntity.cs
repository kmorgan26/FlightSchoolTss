namespace WebApiTraining.Data.Abstractions;

public abstract class AuditEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
}
