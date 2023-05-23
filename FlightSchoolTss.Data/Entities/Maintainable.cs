namespace FlightSchoolTss.Data.Entities;

public partial class Maintainable
{
    public int Id { get; set; }

    public virtual ICollection<Configuration> Configurations { get; set; } = new List<Configuration>();

    public virtual ICollection<Lot> Lots { get; set; } = new List<Lot>();

    public virtual ICollection<ManModule> ManModules { get; set; } = new List<ManModule>();

    public virtual ICollection<Platform> Platforms { get; set; } = new List<Platform>();

    public virtual ICollection<Simulator> Simulators { get; set; } = new List<Simulator>();
}
