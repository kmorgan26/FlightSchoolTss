using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Entities
{
    public class Simulator : BaseEntity
    {
        public int PlatformId { get; set; }
        public bool IsActive { get; set; }
        public virtual Platform Platform { get; set; }
    }
}