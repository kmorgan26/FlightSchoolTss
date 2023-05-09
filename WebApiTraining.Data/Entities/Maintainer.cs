using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Entities;
public class Maintainer : BaseEntity
{
    public virtual ICollection<Platform> Platforms { get; set; } = null!;
}