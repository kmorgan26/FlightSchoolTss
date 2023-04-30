using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Entities;

internal class Component : BaseEntity
{
    public Guid UniqueIdentifier { get; set; } = Guid.NewGuid();
    public int ComponentTypeId { get; set; }
}