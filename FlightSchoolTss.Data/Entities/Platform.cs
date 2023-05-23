using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;
public class Platform : BaseEntity
{
    public int MaintainerId { get; set; }

    public int MaintainableId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Lot> Lots { get; set; } = new List<Lot>();

    public virtual Maintainable Maintainable { get; set; } = null!;

    public virtual Maintainer Maintainer { get; set; } = null!;

    public virtual ICollection<Simulator> Simulators { get; set; } = new List<Simulator>();
}