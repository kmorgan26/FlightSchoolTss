using FlightSchoolTss.Data.DTOs.SoftwareSystem;

namespace FlightSchoolCm.UI.Interfaces;

public interface ISoftwareApiClient
{
    Task<IEnumerable<SoftwareSystemDto>> GetSoftwareSystemDtoByMaintainableIdAsync(int id);
}
