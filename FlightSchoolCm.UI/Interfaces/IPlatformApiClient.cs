using FlightSchoolTss.Data.DTOs.Platform;

namespace FlightSchoolCm.UI.Interfaces;

public interface IPlatformApiClient
{
    Task<List<PlatformDetailsDto>> GetPlatformDetailsAsync();
}
