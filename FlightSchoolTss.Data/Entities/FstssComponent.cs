using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;
public class FstssComponent : BaseEntity
{
    public Guid UniqueIdentifier { get; set; } = Guid.NewGuid();
    public int ComponentTypeId { get; set; }
}