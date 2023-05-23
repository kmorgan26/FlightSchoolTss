using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities;

public class ManModule : BaseEntity
{
    public int MaintainableId { get; set; }

    public int LotId { get; set; }

    public virtual Lot Lot { get; set; } = null!;

    public virtual Maintainable Maintainable { get; set; } = null!;
}