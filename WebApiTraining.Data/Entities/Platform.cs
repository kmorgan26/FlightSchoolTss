using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Entities;
public class Platform : BaseEntity
{
    public int MaintainerId { get; set; }

    public bool IsActive { get; set; }

    public virtual Maintainer Maintainer { get; set; } = null!;

    public virtual ICollection<Simulator>? Simulators { get; set; }

    public virtual ICollection<Lot>? Lots { get; set; }
}