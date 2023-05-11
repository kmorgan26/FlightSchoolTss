using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;
public class Maintainer : BaseEntity
{
    public virtual ICollection<Platform> Platforms { get; set; } = null!;
}