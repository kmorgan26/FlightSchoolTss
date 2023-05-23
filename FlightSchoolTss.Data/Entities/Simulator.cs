using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities
{
    public class Simulator : BaseEntity
    {
        public string? Alias { get; set; }

        public int PlatformId { get; set; }
        
        public bool IsActive { get; set; }

        public int MaintainableId { get; set; }

        public virtual Maintainable Maintainable { get; set; } = null!;

        public virtual Platform Platform { get; set; } = null!;

    }
}