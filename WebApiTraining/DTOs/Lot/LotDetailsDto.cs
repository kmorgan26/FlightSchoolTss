using WebApiTraining.DTOs.ManModule;

namespace WebApiTraining.DTOs.Lot;

public class LotDetailsDto : LotDto
{
    public virtual ICollection<ManModuleDto> ManModules { get; set; } = null!;
}