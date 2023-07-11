using FlightSchoolTss.DTOs.ManModule;

namespace FlightSchoolTss.Data.DTOs.Lot;

public class LotDetailsDto : LotDto
{
    public virtual ICollection<ManModuleDto> ManModules { get; set; } = null!;
}