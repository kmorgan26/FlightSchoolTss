using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Entities
{
    public class Lot : BaseEntity
    {
        public int PlatformId { get; set; }

        public int MaintainableId { get; set; }

        public virtual Maintainable Maintainable { get; set; } = null!;

        public virtual ICollection<ManModule> ManModules { get; set; } = new List<ManModule>();

        public virtual Platform Platform { get; set; } = null!;
    }
}