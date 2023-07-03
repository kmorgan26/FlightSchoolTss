using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using FlightSchoolTss.Data.DTOs.SoftwareVersion;

namespace FlightSchoolCm.UI.Interfaces;

public interface ISoftwareApiClient
{
    Task<IEnumerable<SoftwareSystemDto>> GetSoftwareSystemDtosByMaintainableIdAsync(int id);
    Task<IEnumerable<SoftwareVersionDto>> GetSoftwareVersionDtosBySoftwareSystemIdAsync(int id);
}
