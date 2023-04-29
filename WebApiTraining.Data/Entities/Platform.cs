using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Entities;
public class Platform : BaseEntity
{
    public int MaintainerId { get; set; }

    public bool IsActive { get; set; }

    public Maintainer Maintainer { get; set; }
}