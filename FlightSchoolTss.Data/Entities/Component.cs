using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;
public class Component : BaseEntity
{
    public Guid UniqueIdentifier { get; set; } = Guid.NewGuid();
    public int ComponentTypeId { get; set; }
}